using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("EMPRESA")]
    public class EMPRESA
    {
        public int ID { get; set; }
        public string NOME_FANTASIA { get; set; } = string.Empty;
        public string RAZAO_SOCIAL { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public int ENDERECOID { get; set; }
        public ENDERECO? ENDERECO { get; set; }
        public string TELEFONE { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public DateTime DATA_CRIACAO_EMPRESA { get; set; }
        public DateTime DATA_CRIACAO_CADASTRO { get; set; }
        public int EMPRESA_ATIVA { get; set; } = 0;
    }
}