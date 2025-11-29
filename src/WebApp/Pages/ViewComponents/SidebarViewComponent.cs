using Microsoft.AspNetCore.Mvc;

namespace WebApp.Pages.ViewComponents;
public class SidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}