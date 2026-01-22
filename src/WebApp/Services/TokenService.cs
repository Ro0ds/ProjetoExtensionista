using WebApp.Interfaces;

namespace WebApp.Services;
public class TokenService : ITokenService
{
    private IHttpContextAccessor _contextAccessor;
    private const string TOKEN_SESSION_KEY = "token";
    private const string TOKEN_COOKIE_KEY = ".InovarJunto.Auth";

    public TokenService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string PegarToken()
    {
        // cookie consistente
        var cookieToken = _contextAccessor.HttpContext.Request.Cookies[TOKEN_COOKIE_KEY];
        if(!string.IsNullOrWhiteSpace(cookieToken))
            return cookieToken;

        // session
        return _contextAccessor.HttpContext.Session.GetString(TOKEN_SESSION_KEY) ?? string.Empty;
    }

    public void ArmazenarToken(string token, bool manterLogado = false)
    {
        if(manterLogado)
        {
            // cookie persistente
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(30)
            };
            _contextAccessor.HttpContext.Response.Cookies.Append(TOKEN_COOKIE_KEY, token, cookieOptions);
        }
        else
        {
            // session temporaria
            _contextAccessor.HttpContext.Session.SetString(TOKEN_SESSION_KEY, token);
        }
    }

    public void RemoverToken()
    {
        // removendo cookie
        _contextAccessor.HttpContext.Response.Cookies.Delete(TOKEN_COOKIE_KEY);
        _contextAccessor.HttpContext.Session.Remove(TOKEN_SESSION_KEY);
    }
}