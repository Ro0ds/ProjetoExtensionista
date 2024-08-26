using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoExtensionista.Models
{
    [Table("USUARIO_PERMISSAO")]
    public class USUARIO_PERMISSAO
    {
        [ForeignKey(nameof(USUARIO))]
        public int USUARIO_ID { get; set; }
        public USUARIO? USUARIO { get; set; }

        [ForeignKey(nameof(PERMISSAO))]
        public int PERMISSAO_ID { get; set; }
        public PERMISSAO? PERMISSAO { get; set; }
    }
}