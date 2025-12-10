using Common.DTO.Requisicao.Empresa.Cadastro;
using Common.DTO.Resposta.Empresa.Cadastro;

namespace Api.Interfaces.Empresa.Cadastro;
public interface IEmpresaCadastroServico
{
    Task<EmpresaCadastroResposta> Cadastrar(EmpresaCadastroRequisicao requisicao);
}