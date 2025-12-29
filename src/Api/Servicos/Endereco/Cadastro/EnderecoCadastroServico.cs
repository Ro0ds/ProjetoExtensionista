using Api.Interfaces.Endereco.Cadastro;
using Common.DTO.Requisicao.Endereco.Cadastro;
using Common.DTO.Resposta.Endereco.Cadastro;
using Common.Models;

namespace Api.Servicos.Endereco.Cadastro;

public class EnderecoCadastroServico : IEnderecoCadastroServico
{
    private readonly IEnderecoCadastroRepositorio _cadastroRepositorio;

    public EnderecoCadastroServico(IEnderecoCadastroRepositorio cadastroRepositorio)
    {
        _cadastroRepositorio = cadastroRepositorio;
    }

    public async Task<EnderecoCadastroResposta> Cadastrar(EnderecoCadastroRequisicao requisicao)
    {
        // criar o objeto de resposta que será a base
        var resposta = new EnderecoCadastroResposta();

        // verificar se a requisição não é nula
        if(requisicao == null)
        {
            resposta.Sucesso = false;
            resposta.AdicionarErro("O endereço não pode ser vazio.");
            return resposta;
        }

        // verificar se os campos estão preenchidos corretamente
        var camposVerificados = requisicao.VerificarCampos(requisicao);

        if(camposVerificados.Sucesso == false)
        {
            resposta.Sucesso = false;
            if(camposVerificados.Erros.Length > 1)
                resposta.AdicionarErros(camposVerificados.Erros);
            else
                resposta.AdicionarErro(camposVerificados.Erros[0]);

            return resposta;
        }

        // está tudo ok, montar o objeto de endereco
        var endereco = requisicao.MontarEndereco(camposVerificados.requisicao);

        // chamar o repositorio e salvar no banco
        resposta = await _cadastroRepositorio.Cadastrar(endereco);

        return resposta;
    }
}