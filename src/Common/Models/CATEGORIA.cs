using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("CATEGORIA")]
    public class CATEGORIA
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string NOME { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? DESCRICAO { get; set; } = string.Empty;

        public DateTime DATA_CRIACAO { get; set; } = DateTime.Now;
    }
}
