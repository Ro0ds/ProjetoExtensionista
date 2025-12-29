using Common.DTO.Requisicao.Usuario.Cadastro;
using Common.DTO.Resposta.Usuario.Cadastro;

namespace Api.Interfaces.Usuario.Cadastro
{
    public interface IUsuarioCadastroServico
    {
        Task<UsuarioCadastroResposta> CadastrarUsuario(UsuarioCadastroRequisicao user);
    }
}
