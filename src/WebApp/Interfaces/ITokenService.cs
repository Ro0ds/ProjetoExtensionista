namespace WebApp.Interfaces;
public interface ITokenService
{
    void ArmazenarToken(string token, bool manterLogado = false);
    string PegarToken();
    void RemoverToken();
}