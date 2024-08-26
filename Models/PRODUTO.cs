using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoExtensionista.Models
{
    [Table("PRODUTO")]
    public class PRODUTO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(100)]
        public string NOME { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Descrição")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(255)]
        public string DESCRICAO { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency, ErrorMessage = "Campo {} é obrigatório.")]
        public decimal PRECO { get; set; }

        [Required]
        [Display(Name = "Data criação")]
        [DataType(DataType.DateTime, ErrorMessage = "Campo {} é obrigatório.")]
        public DateTime DATA_CRIACAO { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        [DataType(DataType.Custom, ErrorMessage = "Campo {} é obrigatório.")]
        public int ATIVO { get; set; }

        public CATEGORIA? CATEGORIA { get; set; }
        public int CATEGORIA_ID { get; set; }

        public EMPRESA? EMPRESA { get; set; }
        public int EMPRESA_ID { get; set; }

        public USUARIO? USUARIO { get; set; }
        public int USUARIO_ID { get; set; }

    }
}