using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("FUNCIONARIO")]
    public class FUNCIONARIO
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(USUARIO))]
        public int USUARIOID { get; set; }
        public USUARIO? USUARIO { get; set; }

        [ForeignKey(nameof(EMPRESA))]
        public int EMPRESAID { get; set; }
        public EMPRESA? EMPRESA { get; set; }

        public string CARGO { get; set; } = string.Empty;
        public decimal SALARIO { get; set; }
        public DateTime DATA_ADMISSAO { get; set; }
        public DateTime? DATA_DEMISSAO { get; set; }
        public bool ATIVO { get; set; } = true;
    }
}