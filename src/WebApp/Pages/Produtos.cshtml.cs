using Common.DTO.Requisicao.Produto.Movimentacao;
using Common.DTO.Resposta.Produto;
using Common.Enums.HistoricoMovimentacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;

namespace WebApp.Pages
{
    public class ProdutosModel : PageModel
    {
        private readonly ProdutoApiService _produtoApi;

        public ProdutosModel(ProdutoApiService produtoApi)
        {
            _produtoApi = produtoApi;
        }

        public List<ProdutoResposta> Produtos { get; set; } = new List<ProdutoResposta>();

        [BindProperty]
        public int ProdutoId { get; set; }

        [BindProperty]
        public int Quantidade { get; set; }

        [BindProperty]
        public TipoMovimentacao Entrada { get; set; }

        [BindProperty]
        public string Descricao { get; set; } = string.Empty;

        public async Task OnGet()
        {
            Produtos = await _produtoApi.ListarAsync();
        }

        public async Task<IActionResult> OnPostMovimentarAsync()
        {
            if(Quantidade <= 0)
            {
                await OnGet();
                ModelState.AddModelError(string.Empty, "Quantidade deve ser maior que zero");
                return Page();
            }

            var req = new ProdutoMovimentacaoRequisicao
            {
                ProdutoId = ProdutoId,
                Quantidade = Quantidade,
                Descricao = Descricao,
                TipoMovimentacao = Entrada,
            };

            var ok = await _produtoApi.MovimentarAsync(req);

            await OnGet();

            if(!ok)
                ModelState.AddModelError(string.Empty, "Erro ao movimentar estoque.");

            return Page();
        }
    }
}
