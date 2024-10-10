using Api.DTO.Requisicao.Usuario.Login;
using Api.DTO.Resposta.Usuario.Login;
using Api.Interfaces.Usuario.Login;
using Api.Seguranca;

namespace Api.Servicos.Usuario.Login
{
    public class UsuarioLoginServico : IUsuarioLoginServico
    {
        private readonly IUsuarioLoginRepositorio _loginRepositorio;

        public UsuarioLoginServico(IUsuarioLoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }

        public async Task<UsuarioLoginResposta> Logar(UsuarioLoginRequisicao requisicao)
        {
            if(requisicao == null)
            {
                return new UsuarioLoginResposta
                {
                    NOME = string.Empty,
                    TOKEN = string.Empty,
                    MANTER_LOGADO = false,
                    SUCESSO = false,
                    ERROS = "Usuário nulo."
                };
            }

            var resposta = await _loginRepositorio.Logar(requisicao);

            if(resposta.SUCESSO)
            {
                return resposta;
            }

            return new UsuarioLoginResposta
            {
                NOME = string.Empty,
                TOKEN = string.Empty,
                MANTER_LOGADO = false,
                SUCESSO = false,
                ERROS = "Não foi possível fazer login"
            };
        }
    }
}