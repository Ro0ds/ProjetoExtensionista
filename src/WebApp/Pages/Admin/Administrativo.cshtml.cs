using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Interfaces;
using WebApp.JWT;
using Common.Infra;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Common.DTO.Requisicao.Usuario.Operacoes;

namespace WebApp.Pages.Admin
{
    public class AdministrativoModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenService _tokenService;
        private string _token;

        public UsuarioOperacoesConsulta? Usuario { get; set; }

        public AdministrativoModel(ITokenService tokenService, IHttpClientFactory httpClientFactory)
        {
            _tokenService = tokenService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGet()
        {
            var token = _tokenService.PegarToken();

            if(token != null)
                _token = token;

            var usuario = TokenConfig.DecodificarToken(_token);

            var client = _httpClientFactory.CreateClient("extensionistaAPI");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            var resposta = await client.GetAsync(Rotas.BuscarUsuarioPorID + usuario.Id);

            if(resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<UsuarioOperacoesConsulta>(json);

                Usuario = dados;
            }
        }
    }
}
