using System.Text;
using ASP.NET_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace ASP.NET_Core_MVC_Project.Controllers;

[AllowAnonymous]
public class Redirect : Controller
{
    public class Message
    {
        public string title { set; get; } = "";
        public string htmlcontent { set; get; } = "";
        public string urlredirect { set; get; } = "";
        public string urlname { set; get; } = "";

        public int secondwait { set; get; } = 0;
    }

    [HttpGet("Test")]
    public IActionResult Index(Message message)
    {
        return View(message);
    }
}


