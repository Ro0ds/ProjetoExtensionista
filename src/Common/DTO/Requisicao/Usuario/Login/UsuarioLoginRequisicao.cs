using System.ComponentModel.DataAnnotations;

namespace Common.DTO.Requisicao.Usuario.Login
{
    public class UsuarioLoginRequisicao
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O campo {0} não é um e-mail válido.")]
        [MaxLength(50)]
        public string EMAIL { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Length(8, 50, ErrorMessage = "O campo {0} deve ter entre {1} e {2} caracteres.")]
        public string SENHA { get; set; } = string.Empty;

        public bool MANTER_LOGADO { get; set; } = false;
    }
}