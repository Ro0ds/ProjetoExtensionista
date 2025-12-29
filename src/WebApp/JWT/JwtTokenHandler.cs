using WebApp.Interfaces;
using System.Net.Http.Headers;

namespace WebApp.JWT;
public class JwtTokenHandler : DelegatingHandler
{
    private readonly ITokenService _tokenService;

    public JwtTokenHandler(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _tokenService.PegarToken();

        if(!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}