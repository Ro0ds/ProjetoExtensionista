using Api.Dados;
using Api.Interfaces.Empresa.Cadastro;
using Common.DTO.Resposta.Empresa.Cadastro;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorio.Empresa.Cadastro;
public class EmpresaCadastroRepositorio : IEmpresaCadastroRepositorio
{
    private readonly ApiDbContext _context;

    public EmpresaCadastroRepositorio(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<bool> BuscarPorCNPJ(string cnpj)
    {
        var empresa = await _context.EMPRESA
            .Where(e => e.CNPJ == cnpj)
            .SingleOrDefaultAsync();

        return empresa != null;
    }

    public async Task<EmpresaCadastroResposta> Cadastrar(EMPRESA empresa)
    {
        try 
        { 
            _context.EMPRESA.Add(empresa);
            await _context.SaveChangesAsync();

            return new EmpresaCadastroResposta
            {
                EmpresaId = empresa.ID,
                Sucesso = true
            };
        }
        catch(Exception ex)
        {
            var resposta = new EmpresaCadastroResposta();
            resposta.AdicionarErro(ex.Message);
            resposta.Sucesso = false;

            return resposta;
        }
    }
}