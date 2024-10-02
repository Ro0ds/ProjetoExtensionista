using Api.DTO.Requisicao.Usuario.Cadastro;
using Api.DTO.Resposta.Usuario.Cadastro;

namespace Api.Interfaces.Usuario.Cadastro
{
    public interface IUsuarioCadastroServico
    {
        Task<UsuarioCadastroResposta> CadastrarUsuario(UsuarioCadastroRequisicao user);
    }
}
