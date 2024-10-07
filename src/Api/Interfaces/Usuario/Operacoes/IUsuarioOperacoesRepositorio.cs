using Api.DTO.Requisicao.Usuario.Operacoes;
using Api.Models;

namespace Api.Interfaces.Usuario.Operacoes
{
    public interface IUsuarioOperacoesRepositorio
    {
        Task<List<UsuarioOperacoesConsulta>> Listar();
        Task<UsuarioOperacoesConsulta> ListarPorID(int usuarioID);
        Task<USUARIO> ListarBrutoPorID(int usuarioID);
        Task<UsuarioOperacoesConsulta> Atualizar(USUARIO usuarioID);
        Task<bool> Deletar(int usuarioID);
        UsuarioOperacoesConsulta MontarUsuario(USUARIO usuario, List<string> erros = null!, bool sucesso = false);
    }
}