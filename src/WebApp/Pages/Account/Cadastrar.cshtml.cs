using Common.DTO.Requisicao.Usuario.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Account
{
    public class CadastrarModel : PageModel
    {
        [BindProperty]
        public UsuarioCadastroRequisicao Requisicao { get; set; }

        public void OnGet()
        {
            Requisicao = new UsuarioCadastroRequisicao();
        }
    }
}