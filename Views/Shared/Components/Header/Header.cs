using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Project.Components;

public class Header : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
