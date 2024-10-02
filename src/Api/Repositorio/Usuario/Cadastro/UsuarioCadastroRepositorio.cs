using Api.Dados;
using Api.DTO.Requisicao.Usuario.Cadastro;
using Api.DTO.Resposta.Usuario.Cadastro;
using Api.Interfaces.Usuario.Cadastro;

namespace Api.Repositorio.Usuario.Cadastro
{
    // repository é onde o acesso ao banco de dados é feito de fato, ela será chamada pelo service
    public class UsuarioCadastroRepositorio : IUsuarioCadastroRepositorio
    {
        private readonly ApiDbContext _dbContext;

        public UsuarioCadastroRepositorio(ApiDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<UsuarioCadastroResposta> Adicionar(UsuarioCadastroRequisicao user)
        {
            var usuario = user.MontarUsuario();
            usuario.USUARIO_ATIVO = true;

            _dbContext.USUARIO.Add(usuario);
            await _dbContext.SaveChangesAsync();

            var resposta = new UsuarioCadastroResposta(usuario);
            resposta.AdicionarUsuario(usuario);
            
            return resposta;
        }
    }
}