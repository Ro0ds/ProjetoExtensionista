using Api.Dados;
using Api.Interfaces.Empresa.Operacoes;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorio.Empresa.Operacoes;
public class EmpresaOperacoesRepositorio : IEmpresaOperacoesRepositorio
{
    private readonly ApiDbContext _context;

    public EmpresaOperacoesRepositorio(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<List<EMPRESA>> ListarPorUsuario(int usuarioId)
    {
        return await _context.FUNCIONARIO.Where(f => f.USUARIOID == usuarioId)
            .Include(e => e.EMPRESA)
            .Select(e => e.EMPRESA)
            .ToListAsync() ?? new List<EMPRESA>();
    }
}