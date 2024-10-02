using Api.Models;
using Api.DTO.Requisicao.Usuario.Cadastro;
using Api.DTO.Resposta.Usuario.Cadastro;
using Api.Interfaces.Usuario.Cadastro;
using Api.Repositorio.Usuario.Cadastro;

namespace Api.Servicos.Usuario.Cadastro
{
    // service é a classe que aplica todas as regras de negocio e verificações
    public class UsuarioCadastroServico : IUsuarioCadastroServico
    {
        private readonly UsuarioCadastroRepositorio _usuarioRepositorio;

        public UsuarioCadastroServico(UsuarioCadastroRepositorio usuarioRepositorio)
            => _usuarioRepositorio = usuarioRepositorio;

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
            else if(!ValidaEndereco(user.ENDERECO!))
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
                !string.IsNullOrWhiteSpace(user.SOBRENOME) &&
                !string.IsNullOrWhiteSpace(user.EMAIL) &&
                !string.IsNullOrWhiteSpace(user.CPF) &&
                !string.IsNullOrWhiteSpace(user.CONFIRMACAO_SENHA);
        }

        private bool ValidaEndereco(ENDERECO endereco)
        {
            return 
                endereco.NUMERO >= 0 &&
                !string.IsNullOrWhiteSpace(endereco.CEP) &&
                !string.IsNullOrWhiteSpace(endereco.RUA) &&
                !string.IsNullOrWhiteSpace(endereco.BAIRRO) &&
                !string.IsNullOrWhiteSpace(endereco.CIDADE) &&
                !string.IsNullOrWhiteSpace(endereco.ESTADO) &&
                !string.IsNullOrWhiteSpace(endereco.PAIS);
        }
    }
}