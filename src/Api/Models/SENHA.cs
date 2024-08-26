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

        public USUARIO? USUARIO { get; set; }
        public int USUARIO_ID { get; set; }

        public FUNCIONARIO? FUNCIONARIO { get; set; }
        public int FUNCIONARIO_ID { get; set; }
    }
}