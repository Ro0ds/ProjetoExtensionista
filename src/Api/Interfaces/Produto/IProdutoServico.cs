using Common.DTO.Requisicao.Produto.Cadastro;
using Common.DTO.Requisicao.Produto.Movimentacao;
using Common.DTO.Resposta.Base;
using Common.DTO.Resposta.Produto;

namespace Api.Interfaces.Produto;
public interface IProdutoServico
{
    Task<BaseResposta> MovimentarEstoque(ProdutoMovimentacaoRequisicao requisicao);
    Task<BaseResposta> Cadastrar(ProdutoCadastroRequisicao requisicao);
    Task<GenericResponse<List<ProdutoResposta>>> ListarTodos();
}