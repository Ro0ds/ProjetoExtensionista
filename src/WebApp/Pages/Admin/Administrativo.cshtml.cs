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
        private readonly ITokenService _tokenService;
        private readonly HttpClient _httpClient;

        public UsuarioOperacoesConsulta? Usuario { get; set; }

        public AdministrativoModel(ITokenService tokenService, HttpClient httpClient)
        {
            _tokenService = tokenService;
            _httpClient = httpClient;
        }

        public async Task OnGet()
        {
            var token = _tokenService.PegarToken();
            var usuario = TokenConfig.DecodificarToken(token);

            var uriBase = String.Concat(Rotas.APIRoute, Rotas.BuscarUsuarioPorID);

            var httpMessage = new HttpRequestMessage(HttpMethod.Get, uriBase + usuario.Id);
            httpMessage.Headers.Authorization
                = new AuthenticationHeaderValue("Bearer", token);

            var resposta = await _httpClient.SendAsync(httpMessage);

            if(resposta.IsSuccessStatusCode)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<UsuarioOperacoesConsulta>(json);

                Usuario = dados;
            }
        }
    }
}
