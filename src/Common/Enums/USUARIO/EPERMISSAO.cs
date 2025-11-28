using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Common.Enums.USUARIO
{
    public enum EPERMISSAO
    {
        [Display(Name = "Administrador")]
        [Description("Usuário com permissões administrativas do sistema inteiro.")]
        ADMINISTRADOR = 1,

        [Display(Name = "Usuário")]
        [Description("Usuário com permissões básicas do sistema inteiro.")]
        USUARIO,

        [Display(Name = "Responsável")]
        [Description("Usuário com permissões administrativas dentro de uma empresa.")]
        RESPONSAVEL,

        [Display(Name = "Funcionário")]
        [Description("Usuário com permissões básicas dentro de uma empresa.")]
        FUNCIONARIO
    }
}