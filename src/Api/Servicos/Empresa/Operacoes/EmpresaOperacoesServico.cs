using Api.Interfaces.Empresa.Operacoes;
using Common.DTO.Resposta.Empresa.Operacoes;

namespace Api.Servicos.Empresa.Operacoes;
public class EmpresaOperacoesServico : IEmpresaOperacoesServico
{
    private readonly IEmpresaOperacoesRepositorio _repositorio;

    public EmpresaOperacoesServico(IEmpresaOperacoesRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<EmpresaResposta>> ListarPorUsuario(int usuarioId)
    {
        List<EmpresaResposta> resposta = new List<EmpresaResposta>();

        if(usuarioId == 0)
            throw new Exception("Usuario inexistente.");

        var empresas = await _repositorio.ListarPorUsuario(usuarioId);
        if(empresas == null)
            throw new Exception("Empresa inexistente.");
        
        foreach(var empresa in empresas)
        {
            resposta.Add(new EmpresaResposta { Id = empresa.ID, NomeFantasia = empresa.NOME_FANTASIA });
        }

        return resposta;
    }
}