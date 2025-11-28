using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("CATEGORIA")]
    public class CATEGORIA
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
        [Display(Name = "Data criação")]
        [DataType(DataType.DateTime, ErrorMessage = "Campo {} é obrigatório.")]
        public DateTime DATA_CRIACAO { get; set; }

        [ForeignKey(nameof(USUARIO))]
        public int USUARIO_ID { get; set; }
        public USUARIO? USUARIO { get; set; }

        [ForeignKey(nameof(EMPRESA))]
        public int EMPRESA_ID { get; set; }
        public EMPRESA? EMPRESA { get; set; }
    }
}