using Common.DTO.Requisicao.Usuario.Login;
using Common.DTO.Resposta.Usuario.Login;
using Common.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using WebApp.Interfaces;
using WebApp.JWT;

namespace WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        public UsuarioLoginRequisicao Requisicao { get; set; }
        public UsuarioLoginResposta Resposta { get; set; }
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenService _tokenService;
        private string _token;

        public LoginModel(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
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

                _token = token;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(UsuarioLoginRequisicao requisicao)
        {
            var client = _httpClientFactory.CreateClient("extensionistaAPI");

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            var payload = JsonContent.Create(requisicao);

            var response = await client.PostAsync("usuario/login", payload);
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