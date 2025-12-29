using Common.DTO.Requisicao.Usuario.Login;
using Common.Models;
using Common.DTO.Resposta.Usuario.Login;

namespace Api.Interfaces.Usuario.Login
{
    public interface IUsuarioLoginRepositorio
    {
        Task<UsuarioLoginResposta> Logar(UsuarioLoginRequisicao requisicao);
        Task<USUARIO?> BuscarUsuario(string email, string senha);
    }
}