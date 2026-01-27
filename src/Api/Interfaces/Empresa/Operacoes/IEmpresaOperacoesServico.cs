using Common.DTO.Resposta.Empresa.Operacoes;

namespace Api.Interfaces.Empresa.Operacoes;
public interface IEmpresaOperacoesServico
{
    Task<List<EmpresaResposta>> ListarPorUsuario(int usuarioId);
}