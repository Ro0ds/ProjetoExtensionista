using Common.Enums.HistoricoMovimentacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    [Table("HISTORICO_MOVIMENTACOES")]
    public class HISTORICO_MOVIMENTACOES
    {
        // TODO: ao criar DTO, copiar esses campos pra ela e deletar todos os DataAnnotations aqui

        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(PRODUTO))]
        public int PRODUTO_ID { get; set; }
        public PRODUTO? PRODUTO { get; set; }

        [ForeignKey(nameof(USUARIO))]
        public int USUARIO_ID { get; set; }
        public USUARIO? USUARIO { get; set; }

        [ForeignKey(nameof(FUNCIONARIO))]
        public int FUNCIONARIO_ID { get; set; }
        public FUNCIONARIO? FUNCIONARIO { get; set; }

        [Display(Name = "Quantidade")]
        [DataType(DataType.Custom)]
        public int QUANTIDADE { get; set; }

        [Display(Name = "Tipo movimentação")]
        [DataType(DataType.Custom)]
        public TipoMovimentacao TIPO_MOVIMENTACAO { get; set; }

        [Display(Name = "Data movimentação")]
        [DataType(DataType.DateTime)]
        public DateTime DATA_MOVIMENTACAO { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        public string DESCRICAO { get; set; } = string.Empty;
    }
}