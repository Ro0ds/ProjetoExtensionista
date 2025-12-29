using Common.DTO.Requisicao.Endereco.Cadastro;
using Common.DTO.Resposta.Endereco.Cadastro;

namespace Api.Interfaces.Endereco.Cadastro;
public interface IEnderecoCadastroServico
{
    Task<EnderecoCadastroResposta> Cadastrar(EnderecoCadastroRequisicao requisicao);
}