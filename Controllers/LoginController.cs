using Microsoft.AspNetCore.Mvc;

namespace ProjetoExtensionista.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
