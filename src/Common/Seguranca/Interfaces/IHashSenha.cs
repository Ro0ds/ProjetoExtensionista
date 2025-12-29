namespace Api.Seguranca.Interfaces
{
    public interface IHashSenha
    {
        string HashSenha(string senha, byte[] salt);
        byte[] GerarSalt();
    }
}