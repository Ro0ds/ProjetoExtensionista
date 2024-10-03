using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("USUARIO")]
    [PrimaryKey(nameof(ID))]
    [Index(nameof(EMAIL), IsUnique = true)]
    public class USUARIO
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
        [DataType(DataType.Text)]
        public string FOTO { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CPF")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(11)]
        public string CPF { get; set; } = string.Empty;

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string TELEFONE { get; set; } = string.Empty;

        [ForeignKey(nameof(SENHA))]
        public int SENHA_ID { get; set; }
        public SENHA? SENHA { get; set; }

        [ForeignKey(nameof(ENDERECO))]
        public int ENDERECO_ID { get; set; }
        public ENDERECO? ENDERECO { get; set; }

        [ForeignKey(nameof(PERMISSAO))]
        public int PERMISSAO_ID { get; set; }
        public PERMISSAO? PERMISSAO { get; set; }

        [Required]
        public bool USUARIO_ATIVO { get; set; } = false;

        [Required]
        public DateTime DATA_CRIADO { get; set; }

        [ForeignKey(nameof(FUNCIONARIO))]
        public int? FUNCIONARIO_ID { get; set; }
        public FUNCIONARIO? FUNCIONARIO { get; set; }
    }
}