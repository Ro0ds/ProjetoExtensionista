namespace WebApp.Interfaces;
public interface ITokenService
{
    void ArmazenarToken(string token);
    string PegarToken();
    void RemoverToken();
}