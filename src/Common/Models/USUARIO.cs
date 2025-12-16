using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("USUARIO")]
    [PrimaryKey(nameof(ID))]
    [Index(nameof(EMAIL), IsUnique = true)]
    public class USUARIO
    {
        public int ID { get; set; }
        public string NOME { get; set; } = string.Empty;
        public string SOBRENOME { get; set; } = string.Empty;
        public string NOME_SOCIAL { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public string FOTO { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string TELEFONE { get; set; } = string.Empty;
        public bool USUARIO_ATIVO { get; set; } = true;
        public DateTime DATA_CRIADO { get; set; }
        public int SENHAID { get; set; }
        public SENHA? SENHA { get; set; }
        public int ENDERECOID { get; set; }
        public ENDERECO? ENDERECO { get; set; }
        public int PERMISSAOID { get; set; }
        public PERMISSAO? PERMISSAO { get; set; }
        public int? FUNCIONARIOID { get; set; }
        public FUNCIONARIO? FUNCIONARIO { get; set; }
    }
}