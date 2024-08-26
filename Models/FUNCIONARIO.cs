using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoExtensionista.Models
{
    [Table("FUNCIONARIO")]
    public class FUNCIONARIO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(100)]
        public string NOME { get; set; } = string.Empty;

        [Display(Name = "Sobrenome")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string SOBRENOME { get; set; } = string.Empty;

        [Display(Name = "Nome Social")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string NOME_SOCIAL { get; set; } = string.Empty;

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Campo {} é obrigatório.")]
        [EmailAddress]
        [MaxLength(50)]
        public string EMAIL { get; set; } = string.Empty;

        [Display(Name = "Foto")]
        [DataType(DataType.ImageUrl)]
        public string FOTO { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CPF")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(11)]
        public string CPF { get; set; } = string.Empty;

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string TELEFONE { get; set; } = string.Empty;

        [Required]
        public SENHA SENHA { get; set; } = new();
        
        [Required]
        [Display(Name = "Cargo")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string CARGO { get; set; } = string.Empty;

        [Required]
        public ENDERECO ENDERECO { get; set; } = new();

        [Required]
        public PERMISSAO PERMISSAO { get; set; } = new();

        [Required]
        public bool USUARIO_ATIVO { get; set; } = false;

        [Required]
        public DateTime DATA_CRIADO { get; set; }

        [Required]
        public DateTime DATA_ADMISSAO { get; set; }

        public DateTime? DATA_DEMISSAO { get; set; }
    }
}