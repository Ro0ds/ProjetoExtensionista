using WebApp.Interfaces;

namespace WebApp.Services;
public class TokenService : ITokenService
{
    private IHttpContextAccessor _contextAccessor;

    public TokenService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string PegarToken()
    {
        return _contextAccessor.HttpContext.Session.GetString("token");
    }

    public void ArmazenarToken(string token)
    {
        _contextAccessor.HttpContext.Session.SetString("token", token);
    }

    public void RemoverToken()
    {
        _contextAccessor.HttpContext.Session.Remove("token");
    }
}