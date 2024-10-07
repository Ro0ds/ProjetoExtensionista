using Api.DTO.Requisicao.Usuario.Operacoes;
using Api.Models;

namespace Api.Interfaces.Usuario.Operacoes
{
    public interface IUsuarioOperacoesServico
    {
        Task<List<UsuarioOperacoesConsulta>> BuscarUsuarios();
        Task<UsuarioOperacoesConsulta> BuscarUsuarioPorID(int usuarioID);
        Task<USUARIO> BuscarUsuarioBrutoPorID(int usuarioID);
        Task<UsuarioOperacoesConsulta> AtualizarUsuario(USUARIO usuario);
        Task<bool> DeletarUsuario(int usuarioID);
    }
}