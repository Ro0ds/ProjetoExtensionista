using Api.Interfaces.Empresa.Cadastro;
using Common.DTO.Requisicao.Empresa.Cadastro;
using Common.DTO.Resposta.Empresa.Cadastro;
using Common.Models;

namespace Api.Servicos.Empresa.Cadastro;
public class EmpresaCadastroServico : IEmpresaCadastroServico
{
    private readonly IEmpresaCadastroRepositorio _cadastroRepositorio;
    public EmpresaCadastroServico(IEmpresaCadastroRepositorio cadastroRepositorio)
    {
        _cadastroRepositorio = cadastroRepositorio;
    }

    public async Task<EmpresaCadastroResposta> Cadastrar(EmpresaCadastroRequisicao requisicao)
    {
        var resposta = new EmpresaCadastroResposta();

        // procura para ver se já existe uma empresa com esse CNPJ cadastrado
        var empresaExiste = await _cadastroRepositorio.BuscarPorCNPJ(requisicao.CNPJ);
        if(empresaExiste)
        {
            resposta.AdicionarErro("Empresa já existe no cadastro");
            resposta.Sucesso = false;
        }

        // verifica se os dados são integros
        var dadosCorretos = VerificarDadosEmpresa(requisicao);
        if(dadosCorretos.Sucesso)
        {
            // monta o objeto da empresa
            var empresa = MontarEmpresa(requisicao);

            // realiza o cadastro
            var cadastroResposta = await _cadastroRepositorio.Cadastrar(empresa);
            return cadastroResposta;
        }

        resposta.Sucesso = false;
        resposta.AdicionarErro("Dados preenchidos incorretamente, verifique e tente novamente.");

        return resposta;
    }

    private EMPRESA MontarEmpresa(EmpresaCadastroRequisicao requisicao)
    {
        return new EMPRESA
        {
            NOME_FANTASIA = requisicao.NomeFantasia,
            RAZAO_SOCIAL = requisicao.RazaoSocial,
            CNPJ = requisicao.CNPJ,
            ENDERECOID = requisicao.EnderecoId,
            TELEFONE = requisicao.Telefone,
            EMAIL = requisicao.Email,
            DATA_CRIACAO_EMPRESA = requisicao.DataCriacaoEmpresa,
            DATA_CRIACAO_CADASTRO = requisicao.DataCriacaoCadastro,
            EMPRESA_ATIVA = 1
        };
    }

    private EmpresaCadastroResposta VerificarDadosEmpresa(EmpresaCadastroRequisicao requisicao)
    {
        if(requisicao.CNPJ.Contains('-') | requisicao.CNPJ.Contains('.'))
        {
            requisicao.CNPJ = requisicao.CNPJ.Replace('-', char.MinValue);
            requisicao.CNPJ = requisicao.CNPJ.Replace('.', char.MinValue);
        }

        return new EmpresaCadastroResposta
        {
            Sucesso = true,
        };
    }
}