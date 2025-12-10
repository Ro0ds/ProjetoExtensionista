using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("ENDERECO")]
    public class ENDERECO
    {
        public int ID { get; set; }
        public string CEP { get; set; } = string.Empty;
        public string RUA { get; set; } = string.Empty;
        public int NUMERO { get; set; }
        public string BAIRRO { get; set; } = string.Empty;
        public string CIDADE { get; set; } = string.Empty;
        public string ESTADO { get; set; } = string.Empty;
        public string PAIS { get; set; } = string.Empty;
    }
}