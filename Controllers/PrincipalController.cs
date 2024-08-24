using Microsoft.AspNetCore.Mvc;

namespace ProjetoExtensionista.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
