using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("SENHA")]
    public class SENHA
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Length(8, 50, ErrorMessage = "{} fora dos parametros.")]
        public string PASSWORD { get; set; } = string.Empty;

        public string HASH { get; set; } = string.Empty;
        public byte[] SALT { get; set; } = new byte[512];
    }
}