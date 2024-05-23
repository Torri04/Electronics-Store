using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core_MVC_Project.Models;

namespace ASP.NET_Core_MVC_Project.Controllers;

[Area("Home")]
public class Home : Controller
{
    private readonly ILogger<Home> _logger;

    public Home(ILogger<Home> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View();
    }
}
