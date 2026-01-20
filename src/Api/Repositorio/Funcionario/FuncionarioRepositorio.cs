using Api.Dados;
using Api.Interfaces.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorio.Funcionario;
public class FuncionarioRepositorio : IFuncionarioRepositorio
{
    private readonly ApiDbContext _context;

    public FuncionarioRepositorio(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<int?> ObterFuncionarioIdPorUsuario(int usuarioId)
    {
        var funcionario = await _context.FUNCIONARIO
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.USUARIOID == usuarioId &&
                                      f.ATIVO == true);

        return funcionario?.ID;
    }

    public async Task<bool> VerificarVinculo(int usuarioId, int empresaId)
    {
        return await _context.FUNCIONARIO
            .AsNoTracking()
            .AnyAsync(f => f.USUARIOID == usuarioId &&
                           f.EMPRESAID == empresaId &&
                           f.ATIVO == true);
    }
}