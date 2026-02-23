using Common.DTO.Requisicao.Usuario.Operacoes;
using Common.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Interfaces;
using WebApp.JWT;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApp.Services;

namespace WebApp.Pages;

public class PrincipalModel : PageModel
{
    private readonly ITokenService _tokenService;
    private readonly IHttpClientFactory _httpClient;
    private readonly ProdutoApiService _produtoApi;

    // dados do dashboard
    public UsuarioOperacoesConsulta Usuario { get; set; }
    public string Token { get; set; } = string.Empty;
    public DashboardStats Stats { get; set; } = new DashboardStats();

    // cards principais
    public int TotalProdutos { get; set; }
    public int EstoqueTotal { get; set; }
    public int EstoqueCritico { get; set; } = 0;
    public decimal ValorTotal { get; set; }

    public PrincipalModel(IHttpClientFactory httpClient, ITokenService tokenService, ProdutoApiService produtoApi)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
        _produtoApi = produtoApi;
    }

    public async Task<IActionResult> OnGet()
    {
        var rotaApi = String.Concat(Rotas.APIRoute, Rotas.BuscarUsuarioPorID);

        Token = _tokenService.PegarToken();
        if(string.IsNullOrEmpty(Token))
            return RedirectToPage("./Account/Login");

        var dadosToken = TokenConfig.DecodificarToken(Token);
        if(dadosToken == null || DateTime.UtcNow > dadosToken.Expira)
        {
            _tokenService.RemoverToken();
            return RedirectToPage("./Account/Login");
        }

        // busca usuario
        await BuscarUsuarioAsync(dadosToken.Id);

        // busca stats do dashboard
        await CarregarDashboardAsync();

        return Page();
    }

    public IActionResult OnPostLogout()
    {
        _tokenService.RemoverToken();
        return RedirectToPage("/Account/Login");
    }

    private async Task BuscarUsuarioAsync(int usuarioId)
    {
        var rotaApi = String.Concat(Rotas.APIRoute, Rotas.BuscarUsuarioPorID + usuarioId);
        
        using var requestMessage = new HttpRequestMessage(HttpMethod.Get, rotaApi);
        requestMessage.Headers.Authorization = new
            AuthenticationHeaderValue("Bearer", Token);

        using var client = _httpClient.CreateClient("extensionistaAPI");
        var resposta = await client.SendAsync(requestMessage);
        if(resposta.IsSuccessStatusCode)
        {
            var json = await resposta.Content.ReadAsStringAsync();
            Usuario = JsonConvert.DeserializeObject<UsuarioOperacoesConsulta>(json);
        }
    }

    private async Task CarregarDashboardAsync()
    {
        try
        {
            var produtos = await _produtoApi.ListarAsync();
            TotalProdutos = produtos.Count;
            EstoqueTotal = produtos.Sum(p => p.EstoqueAtual);
            EstoqueCritico = produtos.Where(p => p.EstoqueAtual < 5).Count();
            ValorTotal = produtos.Sum(p => p.EstoqueAtual * p.Preco);
        }
        catch
        {
            TotalProdutos = 0;
            EstoqueTotal = 0;
        }
    }
}

public class DashboardStats
{
    public string NomeUsuario { get; set; } = string.Empty;
    public string Empresa { get; set; } = string.Empty;
    public DateTime UltimoLogin { get; set; }
}