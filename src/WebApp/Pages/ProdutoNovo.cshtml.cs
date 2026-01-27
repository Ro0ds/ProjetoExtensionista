using Common.DTO.Requisicao.Produto.Cadastro;
using Common.DTO.Resposta.Empresa.Operacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Services;

namespace WebApp.Pages
{
    public class ProdutoNovoModel : PageModel
    {
        private readonly ProdutoApiService _produtoApi;
        private readonly EmpresaApiService _empresaApi;

        public ProdutoNovoModel(ProdutoApiService produtoApi, EmpresaApiService empresaApi)
        {
            _produtoApi = produtoApi;
            _empresaApi = empresaApi;
        }

        [BindProperty]
        public ProdutoCadastroRequisicao Produto { get; set; } = new ProdutoCadastroRequisicao();

        public List<EmpresaResposta> Empresas { get; set; } = new List<EmpresaResposta>();

        public async Task OnGet()
        {
            Empresas = await _empresaApi.ListarMinhasEmpresasAsync();

            if(Empresas.Any())
            {
                Produto.EmpresaId = Empresas.First().Id;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Empresas = await _empresaApi.ListarMinhasEmpresasAsync();

            if(!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach(var erro in erros)
                    Console.WriteLine($"ERRO: {erro}");

                return Page();
            }

            var ok = await _produtoApi.CadastrarAsync(Produto);
            if(!ok)
            {
                ModelState.AddModelError(string.Empty, "Erro na API ao cadastrar");
                return Page();
            }

            return RedirectToPage("/Produtos");
        }
    }
}