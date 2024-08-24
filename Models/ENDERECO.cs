using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoExtensionista.Models
{
    [Table("ENDERECO")]
    public class ENDERECO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "CEP")]
        [DataType(DataType.PostalCode, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(8)]
        public string CEP { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Rua")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(100)]
        public string RUA { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Número")]
        [DataType(DataType.Custom, ErrorMessage = "Campo {} é obrigatório.")]
        public int NUMERO { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(50)]
        public string BAIRRO { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Cidade")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(100)]
        public string CIDADE { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Estado")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(20)]
        public string ESTADO { get; set; } = string.Empty;

        [Display(Name = "País")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(30)]
        public string PAIS { get; set; } = string.Empty;
    }
}