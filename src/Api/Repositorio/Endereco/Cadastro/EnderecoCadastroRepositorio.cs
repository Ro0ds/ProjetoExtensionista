using Api.Dados;
using Api.Interfaces.Endereco.Cadastro;
using Common.DTO.Resposta.Endereco.Cadastro;
using Common.Models;

namespace Api.Repositorio.Endereco.Cadastro;

public class EnderecoCadastroRepositorio : IEnderecoCadastroRepositorio
{
    private readonly ApiDbContext _context;

    public EnderecoCadastroRepositorio(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<EnderecoCadastroResposta> Cadastrar(ENDERECO endereco)
    {
        try
        {
            _context.ENDERECO.Add(endereco);
            await _context.SaveChangesAsync();

            return new EnderecoCadastroResposta
            {
                Sucesso = true,
                EnderecoId = endereco.ID
            };
        }
        catch(Exception ex)
        {
            var resposta = new EnderecoCadastroResposta();
            resposta.Sucesso = false;
            resposta.AdicionarErro($"Erro: {ex.Message}");

            return resposta;
        }
    }
}