using System.Text;
using ASP.NET_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace ASP.NET_Core_MVC_Project.Controllers;

[Area("Identity")]
[Route("Account/Email")]
[AllowAnonymous]
public class EmailConfirmation : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public EmailConfirmation(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public string Email { get; set; }

    public string UrlContinue { set; get; }

    [HttpGet("Success")]
    public async Task<IActionResult> Index([FromQuery] string userId, [FromQuery] string code)
    {
        var user = await _userManager.FindByIdAsync(userId);

        //Decode Email Code
        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);

        if (result.Succeeded)
        {
            return View("Views/Redirect/Index.cshtml", new Redirect.Message
            {
                title = "Thông báo",
                htmlcontent = "Chúc mừng bạn! Email của bạn đã xác thực thành công. Trang sẽ tự động chuyển đến trang đăng nhập trong <span class='sc-reverse'>5</span> giây.",
                urlredirect = "http://localhost:5199/signin",
                urlname = "Đăng nhập",
                secondwait = 5
            });
        }
        return LocalRedirect(Url.Action("Index", "SignUp"));
    }

    [HttpGet("Confirming")]
    public IActionResult GetWaitEmailConfirmation()
    {
        return View("Views/Redirect/Index.cshtml", new Redirect.Message
        {
            title = "Thông báo",
            htmlcontent = "Email của bạn đang được chờ xác nhận!",
            urlredirect = "http://localhost:5199/signin",
            urlname = "Đăng nhập",
            secondwait = 5
        });
    }
}