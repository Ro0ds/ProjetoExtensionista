using Common.DTO.Requisicao.Usuario.Cadastro;
using Common.JWTToken;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebApp.Interfaces;
using WebApp.JWT;

namespace WebApp.Pages.Account
{
    public class CadastrarModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenService _tokenService;
        private string _token;
        private DadosToken _usuario;

        [BindProperty]
        public UsuarioCadastroRequisicao Requisicao { get; set; }

        public bool ShowSuccessMessage { get; set; } = false;

        public CadastrarModel(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
            _tokenService = tokenService;
        }

        public void OnGet()
        {
            Requisicao = new UsuarioCadastroRequisicao();

            var token = _tokenService.PegarToken();
            if(token != null)
            {
                _usuario = TokenConfig.DecodificarToken(token);
                _token = token;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // cria o client
            var client = _httpClientFactory.CreateClient("extensionistaAPI");

            // header com token
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            // serializa o conteudo
            var payload = JsonContent.Create(Requisicao);

            // executa o post
            var response = await client.PostAsync("usuario/cadastro/CadastrarUsuario", payload);

            if(response.IsSuccessStatusCode)
            {
                ShowSuccessMessage = true;
                return Page();
                //return RedirectToPage("/admin/Administrativo");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, $"Erro na API: {errorContent}");
                return Page();
            }
        }
    }
}