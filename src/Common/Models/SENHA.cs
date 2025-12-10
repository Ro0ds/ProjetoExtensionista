using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("SENHA")]
    public class SENHA
    {
        public int ID { get; set; }
        public string PASSWORD { get; set; } = string.Empty;
        public string HASH { get; set; } = string.Empty;
        public byte[] SALT { get; set; } = new byte[512];
    }
}