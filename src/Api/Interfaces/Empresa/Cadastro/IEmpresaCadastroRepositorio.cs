using Common.DTO.Resposta.Empresa.Cadastro;
using Common.Models;

namespace Api.Interfaces.Empresa.Cadastro;
public interface IEmpresaCadastroRepositorio
{
    Task<EmpresaCadastroResposta> Cadastrar(EMPRESA empresa);
    Task<bool> BuscarPorCNPJ(string cnpj);
}