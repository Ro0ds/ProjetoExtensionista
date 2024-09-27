using Api.Models;

namespace Api.Interfaces.Usuario.Operacoes
{
    public interface IUsuarioOperacoes
    {
        Task<List<USUARIO>> ConsultarUsuarios();
        Task<USUARIO> ConsultarUsuarioPorID(int usuarioID);
        Task<USUARIO> EditarUsuario(int usuarioID);
        Task<USUARIO> DeletarUsuario(USUARIO usuario);
    }
}