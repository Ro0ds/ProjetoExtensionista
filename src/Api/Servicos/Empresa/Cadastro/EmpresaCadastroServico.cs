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

        // verifica se os dados são integros
        requisicao.CNPJ = LimparCnpj(requisicao.CNPJ);

        if(requisicao.CNPJ.Length != 14)
        {
            resposta.AdicionarErro("CNPJ inválido (tamanho incorreto)");
            resposta.Sucesso = false;
            return resposta;
        }

        // procura para ver se já existe uma empresa com esse CNPJ cadastrado
        var empresaExiste = await _cadastroRepositorio.BuscarPorCNPJ(requisicao.CNPJ);
        if(empresaExiste)
        {
            resposta.AdicionarErro("Empresa já existe no cadastro");
            resposta.Sucesso = false;
            return resposta;
        }

        
        // monta o objeto da empresa
        var empresa = MontarEmpresa(requisicao);

        // realiza o cadastro
        return await _cadastroRepositorio.Cadastrar(empresa);
    }

    private EMPRESA MontarEmpresa(EmpresaCadastroRequisicao requisicao)
    {
        var novaEmpresa = new EMPRESA
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

        if(requisicao.Endereco != null)
        {
            novaEmpresa.ENDERECO = new ENDERECO
            {
                CEP = requisicao.Endereco.CEP,
                RUA = requisicao.Endereco.RUA,
                NUMERO = requisicao.Endereco.NUMERO,
                BAIRRO = requisicao.Endereco.BAIRRO,
                CIDADE = requisicao.Endereco.CIDADE,
                ESTADO = requisicao.Endereco.ESTADO,
                PAIS = requisicao.Endereco.PAIS
            };
        }

        return novaEmpresa;
    }

    private string LimparCnpj(string cnpj)
    {
        if(string.IsNullOrEmpty(cnpj)) return string.Empty;
        // Remove pontos, traços e barras
        return cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
    }
}