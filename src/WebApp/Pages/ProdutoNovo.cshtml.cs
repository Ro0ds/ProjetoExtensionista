using Common.DTO.Requisicao.Produto.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;

namespace WebApp.Pages
{
    public class ProdutoNovoModel : PageModel
    {
        private readonly ProdutoApiService _produtoApi;

        public ProdutoNovoModel(ProdutoApiService produtoApi)
        {
            _produtoApi = produtoApi;
        }

        [BindProperty]
        public ProdutoCadastroRequisicao Produto { get; set; } = new ProdutoCadastroRequisicao();

        public async Task OnGet()
        {
            // testes
            Produto.EmpresaId = 2;
            Produto.CategoriaId = 1;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();

            var ok = await _produtoApi.CadastrarAsync(Produto);
            if(!ok)
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar produto");
                return Page();
            }

            return RedirectToPage("/Produtos");
        }
    }
}