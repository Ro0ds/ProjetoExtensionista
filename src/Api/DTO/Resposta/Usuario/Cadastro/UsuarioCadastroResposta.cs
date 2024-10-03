using Api.Models;

namespace Api.DTO.Resposta.Usuario.Cadastro
{
    public class UsuarioCadastroResposta
    {
        public bool SUCESSO { get; set; }
        public USUARIO? _USUARIO { get; private set; }
        public List<string> ERROS { get; set; }

        public UsuarioCadastroResposta(USUARIO? usuario = null)
        {
            ERROS = new List<string>();
            
            SUCESSO = usuario != null;

            if(SUCESSO)
            {
                AdicionarUsuario(usuario!);
            }

            if(!SUCESSO && _USUARIO == null)
            {
                ERROS.Add("Usuário não registrado.");
            }
        }

        public void AdicionarErro(string erro)
        {
            SUCESSO = false;
            ERROS.Add(erro);
        }

        public void AdicionarUsuario(USUARIO usuario)
        {
            SUCESSO = true;
            _USUARIO = usuario;
        }

        public (bool, object) UsuarioFoiCadastrado(bool cadastrado, USUARIO usuario)
        {
            if(cadastrado)
            {
                SUCESSO = true;
                _USUARIO = usuario;
                ERROS.Clear();

                return (SUCESSO, _USUARIO);
            }

            ERROS.Add("Usuário não cadastrado");
            SUCESSO = false;
            return (SUCESSO, ERROS);
        }
    }
}