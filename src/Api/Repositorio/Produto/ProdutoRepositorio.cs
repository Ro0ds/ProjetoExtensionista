using Api.Dados;
using Api.Interfaces.Produto;
using Common.DTO.Resposta.Base;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorio.Produto;
public class ProdutoRepositorio : IProdutoRepositorio
{
    private readonly ApiDbContext _context;

    public ProdutoRepositorio(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<BaseResposta> Cadastrar(PRODUTO produto)
    {
        var resposta = new BaseResposta();
        try
        {
            _context.PRODUTO.Add(produto);
            await _context.SaveChangesAsync();
            resposta.Sucesso = true;
        }
        catch (Exception ex)
        {
            resposta.AdicionarErro($"Erro ao salvar produto: {ex.Message}");
        }

        return resposta;
    }

    public async Task<List<PRODUTO>> ListarTodos()
    {
        return await _context.PRODUTO
            .Include(p => p.CATEGORIA)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<BaseResposta> RealizarMovimentacao(HISTORICO_MOVIMENTACOES historico)
    {
        var resposta = new BaseResposta();

        // inicia transação
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var produto = await _context.PRODUTO
                .FirstOrDefaultAsync(p => p.ID == historico.PRODUTOID);

            if(produto == null)
                throw new Exception("Produto não encontrado");

            // calcula o novo saldo
            if(historico.TIPO_MOVIMENTACAO == Common.Enums.HistoricoMovimentacoes.TipoMovimentacao.ENTRADA)
                produto.ESTOQUE_ATUAL += historico.QUANTIDADE;
            else
            {
                if(produto.ESTOQUE_ATUAL < historico.QUANTIDADE)
                    throw new Exception("Estoque insuficiente para esta saída");

                produto.ESTOQUE_ATUAL -= historico.QUANTIDADE;
            }

            historico.DATA_MOVIMENTACAO = DateTime.UtcNow;
            _context.HISTORICO_MOVIMENTACOES.Add(historico);

            _context.PRODUTO.Update(produto);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            resposta.Sucesso = true;
        }
        catch(Exception ex)
        {
            await transaction.RollbackAsync();
            resposta.Sucesso = false;
            resposta.AdicionarErro(ex.Message);
        }

        return resposta;
    }
}