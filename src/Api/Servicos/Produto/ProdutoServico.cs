using Api.Interfaces.Funcionario;
using Api.Interfaces.Produto;
using Common.DTO.Requisicao.Produto.Cadastro;
using Common.DTO.Requisicao.Produto.Movimentacao;
using Common.DTO.Resposta.Base;
using Common.DTO.Resposta.Produto;
using Common.Enums.HistoricoMovimentacoes;
using Common.Models;

namespace Api.Servicos.Produto;
public class ProdutoServico : IProdutoServico
{
    private readonly IProdutoRepositorio _produtoRepositorio;
    private readonly IFuncionarioRepositorio _funcionarioRepositorio;

    public ProdutoServico(IProdutoRepositorio repositorio, IFuncionarioRepositorio funcionarioRepositorio)
    {
        _produtoRepositorio = repositorio;
        _funcionarioRepositorio = funcionarioRepositorio;
    }

    public async Task<BaseResposta> Cadastrar(ProdutoCadastroRequisicao requisicao)
    {
        var temPermissao = await _funcionarioRepositorio.VerificarVinculo(requisicao.UsuarioId, requisicao.EmpresaId);

        if(!temPermissao)
        {
            var resp = new BaseResposta();
            resp.AdicionarErro("Usuário não tem permissão nesta empresa");
            return resp;
        }

        var produto = new PRODUTO
        {
            NOME = requisicao.Nome,
            DESCRICAO = requisicao.Descricao,
            PRECO = requisicao.Preco,
            CATEGORIAID = requisicao.CategoriaId,
            EMPRESAID = requisicao.EmpresaId,
            USUARIOID = requisicao.UsuarioId,

            // padrões
            ESTOQUE_ATUAL = 0,
            DATA_CRIACAO = DateTime.UtcNow,
            ATIVO = 1
        };

        return await _produtoRepositorio.Cadastrar(produto);
    }

    public async Task<GenericResponse<List<ProdutoResposta>>> ListarTodos()
    {
        var produtosBanco = await _produtoRepositorio.ListarTodos();

        var listaDto = produtosBanco.Select(p => new ProdutoResposta
        {
            Id = p.ID,
            Nome = p.NOME,
            Descricao = p.DESCRICAO,
            Preco = p.PRECO,
            EstoqueAtual = p.ESTOQUE_ATUAL,
            Categoria = p.CATEGORIA?.NOME ?? "Sem Categoria"
        }).ToList();

        return new GenericResponse<List<ProdutoResposta>> { Sucesso = true, Dados = listaDto };
    }

    public async Task<BaseResposta> MovimentarEstoque(ProdutoMovimentacaoRequisicao requisicao)
    {
        var funcionarioId = await _funcionarioRepositorio.ObterFuncionarioIdPorUsuario(requisicao.UsuarioId);

        if(funcionarioId == null)
        {
            var resp = new BaseResposta();
            resp.AdicionarErro("Usuário não está vinculado a nenhum funcionário");
            return resp;

        }

        var historico = new HISTORICO_MOVIMENTACOES
        {
            PRODUTOID = requisicao.ProdutoId,
            USUARIOID = requisicao.UsuarioId,
            FUNCIONARIOID = funcionarioId.Value,
            QUANTIDADE = requisicao.Quantidade,
            TIPO_MOVIMENTACAO = (TipoMovimentacao)requisicao.TipoMovimentacao,
            DESCRICAO = requisicao.Descricao,
           DATA_MOVIMENTACAO = DateTime.UtcNow
        };

        return await _produtoRepositorio.RealizarMovimentacao(historico);
    }
}