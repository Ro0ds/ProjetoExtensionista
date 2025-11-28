using Common.DTO.Requisicao.Usuario.Cadastro;
using Common.DTO.Resposta.Usuario.Cadastro;

namespace Api.Interfaces.Usuario.Cadastro
{
    public interface IUsuarioCadastroRepositorio
    {
        Task<UsuarioCadastroResposta> Adicionar(UsuarioCadastroRequisicao user);
    }
}