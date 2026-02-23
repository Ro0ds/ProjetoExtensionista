using Common.DTO.Requisicao.Usuario.Login;
using Common.DTO.Resposta.Usuario.Login;
using Common.Infra;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Interfaces;
using WebApp.JWT;

namespace WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        public UsuarioLoginRequisicao Requisicao { get; set; }
        public UsuarioLoginResposta Resposta { get; set; }
        private readonly HttpClient _httpClient;
        private readonly ITokenService _tokenService;

        public LoginModel(HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var token = _tokenService.PegarToken();
            if(!string.IsNullOrEmpty(token))
            {
                var dadosToken = TokenConfig.DecodificarToken(token);
                if(DateTime.UtcNow < dadosToken.Expira)
                {
                    return RedirectToPage("../Principal");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(UsuarioLoginRequisicao requisicao)
        {
            var rotaApi = String.Concat(Rotas.APIRoute, Rotas.UsuarioLogin);

            var response = await _httpClient.PostAsJsonAsync(rotaApi, requisicao);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var resposta = JsonConvert.DeserializeObject<UsuarioLoginResposta>(content);

                if(resposta != null)
                {
                    _tokenService.ArmazenarToken(resposta.TOKEN, requisicao.MANTER_LOGADO);
                    return RedirectToPage("../Principal");
                }
            }

            ModelState.AddModelError(string.Empty, "E-mail ou senha incorretos");
            return Page();
        }
    }
}