using Common.DTO.Requisicao.Usuario.Login;
using Common.DTO.Resposta.Usuario.Login;
using Common.Infra;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Interfaces;

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

        public async Task OnGetAsync()
        {
            // apenas o get da p�gina
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