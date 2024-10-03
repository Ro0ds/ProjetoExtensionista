using Api.Models;
using Api.Seguranca;
using System.ComponentModel.DataAnnotations;

namespace Api.DTO.Requisicao.Usuario.Cadastro
{
    public class UsuarioCadastroRequisicao
    {
        [Required]
        [Display(Name = "Nome")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(100)]
        public string NOME { get; set; }

        [Display(Name = "Sobrenome")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string SOBRENOME { get; set; }

        [Display(Name = "Nome Social")]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string NOME_SOCIAL { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Campo {} é obrigatório.")]
        [EmailAddress]
        [MaxLength(50)]
        public string EMAIL { get; set; }

        [Display(Name = "Foto")]
        [DataType(DataType.Text)]
        public string FOTO { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [DataType(DataType.Text, ErrorMessage = "Campo {} é obrigatório.")]
        [MaxLength(11)]
        public string CPF { get; set; } 

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string TELEFONE { get; set; }

        public string CONFIRMACAO_SENHA { get; set; } = string.Empty;

        public ENDERECO? ENDERECO { get; set; }

        public PERMISSAO? PERMISSAO { get; set; }

        [Required]
        public bool USUARIO_ATIVO { get; set; } = false;

        [Required]
        public DateTime DATA_CRIADO { get; set; }

        public bool SUCESSO { get; set; }
        public List<string> ERROS { get; set; } = [];

        public UsuarioCadastroRequisicao()
        {
            DATA_CRIADO = DateTime.Now;
            SUCESSO = false;
            ERROS.Clear();
        }

        public void AdicionarErro(string erro)
        {
            SUCESSO = false;
            ERROS.Add(erro);
        }

        public USUARIO MontarUsuario()
        {
            Senha senhaHashing = new Senha();
            string senha = this.CONFIRMACAO_SENHA;

            byte[] saltBytes = senhaHashing.GerarSalt();

            // faz o hash da senha com o salt
            string hashedPassword = senhaHashing.HashSenha(senha, saltBytes);
            string base64Salt = Convert.ToBase64String(saltBytes);
            byte[] retrieveSaltBytes = Convert.FromBase64String(base64Salt);

            return new USUARIO
            {
                NOME = this.NOME,
                SOBRENOME = this.SOBRENOME,
                NOME_SOCIAL = this.NOME_SOCIAL,
                EMAIL = this.EMAIL,
                FOTO = this.FOTO,
                CPF = this.CPF,
                TELEFONE = this.TELEFONE,
                SENHA = new SENHA
                {
                    PASSWORD = base64Salt,
                    HASH = hashedPassword,
                    SALT = retrieveSaltBytes
                },
                ENDERECO = this.ENDERECO,
                PERMISSAO = this.PERMISSAO,
                USUARIO_ATIVO = this.USUARIO_ATIVO,
                DATA_CRIADO = DateTime.Now
            };
        }
    }
}