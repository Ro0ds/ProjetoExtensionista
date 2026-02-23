using Common.Models;

namespace Api.Interfaces.Empresa.Operacoes;
public interface IEmpresaOperacoesRepositorio
{
    Task<List<EMPRESA>> ListarPorUsuario(int usuarioId);
}