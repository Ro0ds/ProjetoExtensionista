using Common.DTO.Requisicao.Empresa.Cadastro;
using Common.JWTToken;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Interfaces;
using WebApp.JWT;

namespace WebApp.Pages.Empresa;
public class CadastrarModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenService _tokenService;
    private string _token;
    private DadosToken _usuario;

    [BindProperty]
    public EmpresaCadastroRequisicao Requisicao { get; set; }
    public bool ShowSuccessMessage { get; set; } = false;

    public CadastrarModel(IHttpClientFactory httpClientFactory, ITokenService tokenService)
    {
        _httpClientFactory = httpClientFactory;
        _tokenService = tokenService;
    }

    public void OnGet()
    {
        Requisicao = new EmpresaCadastroRequisicao();

        var token = _tokenService.PegarToken();
        if(token != null)
        {
            _usuario = TokenConfig.DecodificarToken(token);
            _token = token;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _httpClientFactory.CreateClient("extensionistaAPI");

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _token);

        var payload = JsonContent.Create(Requisicao);

        var response = await client.PostAsync("empresacadastro/cadastrar", payload);

        if(response.IsSuccessStatusCode)
        {
            ShowSuccessMessage = true;
            return Page();
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, $"Erro: {errorContent}");
            return Page();
        }
    }
}