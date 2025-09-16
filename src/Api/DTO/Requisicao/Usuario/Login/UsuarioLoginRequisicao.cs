using System.ComponentModel.DataAnnotations;

namespace Api.DTO.Requisicao.Usuario.Login
{
    public class UsuarioLoginRequisicao
    {
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(50)]
        public string EMAIL { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Length(8, 50, ErrorMessage = "{} fora dos parametros.")]
        public string SENHA { get; set; } = string.Empty;

        public bool MANTER_LOGADO { get; set; } = false;
    }
}