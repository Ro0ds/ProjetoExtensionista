using Api.DTO.Requisicao.Usuario.Cadastro;
using Api.DTO.Resposta.Usuario.Cadastro;

namespace Api.Interfaces.Usuario.Cadastro
{
    public interface IUsuarioCadastroRepositorio
    {
        Task<UsuarioCadastroResposta> Adicionar(UsuarioCadastroRequisicao user);
    }
}