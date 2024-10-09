using Api.DTO.Requisicao.Usuario.Cadastro;
using Api.DTO.Resposta.Usuario.Cadastro;
using Api.Interfaces.Usuario.Cadastro;

namespace Api.Servicos.Usuario.Cadastro
{
    // service é a classe que aplica todas as regras de negocio e verificações
    public class UsuarioCadastroServico : IUsuarioCadastroServico
    {
        private readonly IUsuarioCadastroRepositorio _usuarioRepositorio;

        public UsuarioCadastroServico(IUsuarioCadastroRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioCadastroResposta> CadastrarUsuario(UsuarioCadastroRequisicao user)
        {
            if(user == null)
            {
                return new UsuarioCadastroResposta
                { 
                    SUCESSO = false, 
                    ERROS = ["Cadastro não pode ser vazio."]
                };
            }
            else if(!ValidaDadosBasicos(user)) 
            {
                user.AdicionarErro("Dados básicos não preenchidos corretamente");
                user.SUCESSO = false;

                return new UsuarioCadastroResposta
                {
                    SUCESSO = user.SUCESSO,
                    ERROS = user.ERROS
                };
            }
            else if(!ValidaEndereco(user))
            {
                user.AdicionarErro("Endereço não pode ser vazio.");
                user.SUCESSO = false;

                return new UsuarioCadastroResposta
                {
                    SUCESSO = user.SUCESSO,
                    ERROS = user.ERROS
                };
            }

            return await _usuarioRepositorio.Adicionar(user);
        }

        // verificações de cadastro
        private bool ValidaDadosBasicos(UsuarioCadastroRequisicao user)
        {
            return 
                !string.IsNullOrWhiteSpace(user.NOME) &&
                !string.IsNullOrWhiteSpace(user.EMAIL) &&
                !string.IsNullOrWhiteSpace(user.CPF) &&
                !string.IsNullOrWhiteSpace(user.CONFIRMACAO_SENHA);
        }

        private bool ValidaEndereco(UsuarioCadastroRequisicao user)
        {
            return 
                user.ENDERECO!.NUMERO > 0 &&
                !string.IsNullOrWhiteSpace(user.ENDERECO!.CEP) &&
                !string.IsNullOrWhiteSpace(user.ENDERECO!.RUA) &&
                !string.IsNullOrWhiteSpace(user.ENDERECO!.BAIRRO) &&
                !string.IsNullOrWhiteSpace(user.ENDERECO!.CIDADE) &&
                !string.IsNullOrWhiteSpace(user.ENDERECO!.ESTADO) &&
                !string.IsNullOrWhiteSpace(user.ENDERECO!.PAIS);
        }
    }
}