using System.ComponentModel.DataAnnotations;

namespace Common.DTO.Requisicao.Produto.Cadastro;
public class ProdutoCadastroRequisicao
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Descricao { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
    public decimal Preco { get; set; }

    public int CategoriaId { get; set; }
    public int EmpresaId { get; set; }

    public int UsuarioId { get; set; }
}