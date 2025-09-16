using Api.DTO.Requisicao.Usuario.Login;
using Api.DTO.Resposta.Usuario.Login;

namespace Api.Interfaces.Usuario.Login
{
    public interface IUsuarioLoginServico
    {
        Task<UsuarioLoginResposta> Logar(UsuarioLoginRequisicao requisicao);
        Task<int> BuscarUsuario(string email, string senha);
    }
}