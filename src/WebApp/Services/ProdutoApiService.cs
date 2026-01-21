using WebApp.Interfaces;
using System.Net.Http.Headers;
using Common.DTO.Resposta.Produto;
using Common.DTO.Requisicao.Produto.Cadastro;
using Common.DTO.Requisicao.Produto.Movimentacao;
using Common.DTO.Resposta.Base;

namespace WebApp.Services;
public class ProdutoApiService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenService _tokenService;
    private string _token;

    public ProdutoApiService(IHttpClientFactory httpClientFactory, ITokenService tokenService)
    {
        _httpClientFactory = httpClientFactory;
        _tokenService = tokenService;
    }

    private HttpClient AddDefaultHeaders()
    {
        _token = _tokenService.PegarToken();
        var client = _httpClientFactory.CreateClient("extensionistaAPI");
        client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

        return client;
    }

    public async Task<List<ProdutoResposta>> ListarAsync()
    {
        var client = AddDefaultHeaders();
        var result = await client.GetFromJsonAsync<List<ProdutoResposta>>("Produto");

        return result ?? new List<ProdutoResposta>();
    }

    public async Task<bool> CadastrarAsync(ProdutoCadastroRequisicao requisicao)
    {
        var client = AddDefaultHeaders();

        var response = await client.PostAsJsonAsync("Produto", requisicao);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> MovimentarAsync(ProdutoMovimentacaoRequisicao requisicao)
    {
        var client = AddDefaultHeaders();
        var response = await client.PostAsJsonAsync("Produto/movimentar", requisicao);
        return response.IsSuccessStatusCode;
    }
}