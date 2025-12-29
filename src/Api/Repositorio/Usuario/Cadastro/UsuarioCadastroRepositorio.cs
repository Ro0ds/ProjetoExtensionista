using Api.Dados;
using Common.DTO.Requisicao.Usuario.Cadastro;
using Api.Interfaces.Usuario.Cadastro;
using Common.DTO.Resposta.Usuario.Cadastro;
using Api.Interfaces.Endereco.Cadastro;

namespace Api.Repositorio.Usuario.Cadastro
{
    // repository é onde o acesso ao banco de dados é feito de fato, ela será chamada pelo service
    public class UsuarioCadastroRepositorio : IUsuarioCadastroRepositorio
    {
        private readonly ApiDbContext _dbContext;
        private readonly IEnderecoCadastroRepositorio _enderecoRepositorio;

        public UsuarioCadastroRepositorio(ApiDbContext dbContext, IEnderecoCadastroRepositorio enderecoRepositorio)
        {
            _dbContext = dbContext;
            _enderecoRepositorio = enderecoRepositorio;
        } 

        public async Task<UsuarioCadastroResposta> Adicionar(UsuarioCadastroRequisicao user)
        {
            var usuario = user.MontarUsuario();
            usuario.USUARIO_ATIVO = true;

            await _dbContext.Database.BeginTransactionAsync();

            try
            {
                _dbContext.ENDERECO.Add(usuario.ENDERECO);
                _dbContext.USUARIO.Add(usuario);
                await _dbContext.SaveChangesAsync();
                await _dbContext.Database.CommitTransactionAsync();
                
                var resposta = new UsuarioCadastroResposta(usuario);
                resposta.AdicionarUsuario(usuario);
            
                return resposta;
            }
            catch(Exception ex)
            {
                var resposta = new UsuarioCadastroResposta();
                resposta.SUCESSO = false;
                resposta.AdicionarErro($"Erro ao adicionar usuário: {ex.Message}");

                return resposta;
            }
        }
    }
}