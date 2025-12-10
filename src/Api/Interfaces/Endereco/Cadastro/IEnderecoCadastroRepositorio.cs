using Common.DTO.Resposta.Endereco.Cadastro;
using Common.Models;

namespace Api.Interfaces.Endereco.Cadastro;
public interface IEnderecoCadastroRepositorio
{
    Task<EnderecoCadastroResposta> Cadastrar(ENDERECO endereco);
}