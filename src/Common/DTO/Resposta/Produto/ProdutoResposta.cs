namespace Common.DTO.Resposta.Produto;
public class ProdutoResposta
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int EstoqueAtual { get; set; }
    public string Categoria { get; set; } = string.Empty;
}