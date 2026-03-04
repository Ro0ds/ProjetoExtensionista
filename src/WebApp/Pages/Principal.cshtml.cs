using Common.DTO.Requisicao.Usuario.Operacoes;
using Common.Infra;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApp.Interfaces;
using WebApp.JWT;
using WebApp.Services;

namespace WebApp.Pages;

public class PrincipalModel : PageModel
{
    private readonly ITokenService _tokenService;
    private readonly IHttpClientFactory _httpClientFactory;
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

    public PrincipalModel(IHttpClientFactory httpClientFactory, ITokenService tokenService, ProdutoApiService produtoApi)
    {
        _httpClientFactory = httpClientFactory;
        _tokenService = tokenService;
        _produtoApi = produtoApi;
    }

    public async Task<IActionResult> OnGet()
    {
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
        var client = _httpClientFactory.CreateClient("extensionistaAPI");

        client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token);

        var resposta = await client.GetAsync(Rotas.BuscarUsuarioPorID + usuarioId);
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