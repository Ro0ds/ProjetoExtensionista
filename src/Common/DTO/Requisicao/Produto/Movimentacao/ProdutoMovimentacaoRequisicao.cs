using Common.Enums.HistoricoMovimentacoes;

namespace Common.DTO.Requisicao.Produto.Movimentacao;
public class ProdutoMovimentacaoRequisicao
{
    public int ProdutoId { get; set; }
    public int UsuarioId { get; set; } 
    public int Quantidade { get; set; }
    public TipoMovimentacao TipoMovimentacao { get; set; }
    public string Descricao { get; set; } = string.Empty;
}