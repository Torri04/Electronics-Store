using System.Text;
using ASP.NET_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace ASP.NET_Core_MVC_Project.Controllers;

[Area("Admin")]
[Route("Admin")]
public class Statistics : Controller
{
    [HttpGet("Statistics")]
    public IActionResult Index()
    {
        return View();
    }
}