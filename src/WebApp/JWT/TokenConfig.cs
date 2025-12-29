using Common.JWTToken;
using Microsoft.IdentityModel.JsonWebTokens;

namespace WebApp.JWT;
public class TokenConfig
{
    public static DadosToken DecodificarToken(string token)
    {
        var handler = new JsonWebTokenHandler();
        var jsonToken = handler.ReadJsonWebToken(token);

        var criacao = long.Parse(jsonToken.GetClaim("iat")?.Value!);
        var dataCriacao = DateTimeOffset.FromUnixTimeSeconds(criacao).DateTime;

        var exp = long.Parse(jsonToken.GetClaim("exp")?.Value!);
        var dataExp = DateTimeOffset.FromUnixTimeSeconds(exp).DateTime;

        return new DadosToken
        {
            Id = int.Parse(jsonToken.GetClaim("sub")?.Value!),
            TokenId = Guid.Parse(jsonToken.GetClaim("jti")?.Value!),
            DataCriacao = dataCriacao,
            Permissao = jsonToken.GetClaim("roleId")?.Value!,
            Expira = dataExp
        };
    }
}