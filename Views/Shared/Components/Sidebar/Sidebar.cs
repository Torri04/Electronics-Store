using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Project.Components;

public class Sidebar : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}