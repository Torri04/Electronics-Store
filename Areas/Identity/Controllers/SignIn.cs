using ASP.NET_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_MVC_Project.Controllers
{
    [Area("Identity")]
    [AllowAnonymous]
    public class SignIn : Controller
    {
        private readonly ILogger<SignIn> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public SignIn(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<SignIn> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet("SignIn")]
        public ActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return LocalRedirect(Url.Action("Index", "Home", new { area = "Home" }));
            }
            else
            {
                return View();
            }
        }

        [HttpPost("SignIn")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> PostSignIn([Bind] InputSignIn inputSignIn)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    inputSignIn.UserName ?? "",
                    inputSignIn.Password ?? "",
                    inputSignIn.Remember,
                    false
                );

                if (result.Succeeded)
                {
                    return LocalRedirect(Url.Action("Index", "Home", new { area = "Home" }));
                }
                else
                {
                    ModelState.AddModelError("UserName", "Tên đăng nhập hoặc mật khẩu không chính xác");
                    return View("Areas/Identity/Views/SignIn/Index.cshtml", new InputSignIn { UserName = inputSignIn.UserName, Password = "" });
                }
            }
            return View("Areas/Identity/Views/SignIn/Index.cshtml", new InputSignIn { UserName = inputSignIn.UserName, Password = "" });
        }

    }
}
