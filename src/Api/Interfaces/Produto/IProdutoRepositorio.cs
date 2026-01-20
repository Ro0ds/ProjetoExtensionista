using Common.DTO.Resposta.Base;
using Common.Models;

namespace Api.Interfaces.Produto;
public interface IProdutoRepositorio
{
    Task<BaseResposta> RealizarMovimentacao(HISTORICO_MOVIMENTACOES historico);
    Task<BaseResposta> Cadastrar(PRODUTO produto);
    Task<List<PRODUTO>> ListarTodos();
}