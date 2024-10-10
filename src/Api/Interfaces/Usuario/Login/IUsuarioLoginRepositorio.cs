using Api.DTO.Requisicao.Usuario.Login;
using Api.DTO.Resposta.Usuario.Login;
using Api.Models;

namespace Api.Interfaces.Usuario.Login
{
    public interface IUsuarioLoginRepositorio
    {
        Task<UsuarioLoginResposta> Logar(UsuarioLoginRequisicao requisicao);
        Task<USUARIO?> BuscarUsuario(string email, string senha);
    }
}