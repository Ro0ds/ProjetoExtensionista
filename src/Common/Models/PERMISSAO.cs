using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("PERMISSAO")]
    public class PERMISSAO
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nome da permissão")]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string NOME_PERMISSAO { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Descrição da permissão")]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public string DESCRICAO { get; set; } = string.Empty;
    }
}