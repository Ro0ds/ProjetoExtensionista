using Common.DTO.Requisicao.Usuario.Operacoes;
using Common.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Interfaces;
using WebApp.JWT;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebApp.Pages;

public class PrincipalModel : PageModel
{
    private readonly ITokenService _tokenService;
    private readonly HttpClient _httpClient;

    public UsuarioOperacoesConsulta Usuario { get; set; }
    public string Token { get; set; } = string.Empty;

    public PrincipalModel(HttpClient httpClient, ITokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task<IActionResult> OnGet()
    {
        var rotaApi = String.Concat(Rotas.APIRoute, Rotas.BuscarUsuarioPorID);

        Token = _tokenService.PegarToken();
        if(string.IsNullOrEmpty(Token))
            return RedirectToPage("./Account/Login");

        var dadosToken = TokenConfig.DecodificarToken(Token);

        if(dadosToken != null)
        {
            // monta o header com o token a ser enviado usando o requestMessage
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, rotaApi + dadosToken.Id);
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", Token);

            var resposta = await _httpClient.SendAsync(requestMessage);
            if(resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                Usuario = JsonConvert.DeserializeObject<UsuarioOperacoesConsulta>(json);
            }
        }

        return Page();
    }
}
