using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("EMPRESA")]
    public class EMPRESA
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome Fantasia")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(255)]
        public string NOME_FANTASIA { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Razão Social")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(255)]
        public string RAZAO_SOCIAL { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CNPJ")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(15)]
        public string CNPJ { get; set; } = string.Empty;

        [ForeignKey(nameof(ENDERECO))]
        public int ENDERECO_ID { get; set; }
        public ENDERECO? ENDERECO { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string TELEFONE { get; set; } = string.Empty;

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Campo {} é obrigatório.")]
        [EmailAddress]
        [MaxLength(50)]
        public string EMAIL { get; set; } = string.Empty;

        [Display(Name = "Data de criação da empresa")]
        public DateTime DATA_CRIACAO_EMPRESA { get; set; }

        [Required]
        [Display(Name = "Data de criação do cadastro")]
        public DateTime DATA_CRIACAO_CADASTRO { get; set; }

        [Required]
        public int EMPRESA_ATIVA { get; set; } = 0;
    }
}