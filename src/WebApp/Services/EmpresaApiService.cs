using Common.DTO.Resposta.Empresa.Operacoes;
using System.Net.Http.Headers;
using WebApp.Interfaces;

namespace WebApp.Services;
public class EmpresaApiService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ITokenService _tokenService;

    public EmpresaApiService(IHttpClientFactory clientFactory, ITokenService tokenService)
    {
        _clientFactory = clientFactory;
        _tokenService = tokenService;
    }

    private HttpClient AddDefaultHeaders()
    {
        var token = _tokenService.PegarToken();
        var client = _clientFactory.CreateClient("extensionistaAPI");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return client;
    }

    public async Task<List<EmpresaResposta>> ListarMinhasEmpresasAsync()
    {
        using var client = AddDefaultHeaders();
        var result = await client.GetFromJsonAsync<List<EmpresaResposta>>("empresa/minhas");

        return result ?? new List<EmpresaResposta>();
    }
}