using System.ComponentModel.DataAnnotations;
using System.Text;
using ASP.NET_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace ASP.NET_Core_MVC_Project.Controllers
{
    [Area("Identity")]
    public class SignUp : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<SignUp> _logger;
        private readonly IEmailSender _emailSender;
        public InputSignUp Input { get; set; }

        public SignUp(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<SignUp> logger, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [HttpPost("SignUp")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> OnPostAsync(InputSignUp Input)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = Input.UserName, FullName = Input.FullName, Email = Input.Email, Commitment = Input.Commitment };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    // Generate token for email verification
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = Url.Action("Index", "EmailConfirmation", new { userId = user.Id, code = code }, Request.Scheme);

                    // Send email    
                    await _emailSender.SendEmailAsync(user.Email, "Xác nhận địa chỉ email",
                        $"Hãy xác nhận địa chỉ email bằng cách <a href='{callbackUrl}'>Bấm vào đây</a>.");

                    // Check email verification required or not
                    if (_userManager.Options.SignIn.RequireConfirmedEmail)
                    {
                        return LocalRedirect(Url.Action("GetWaitEmailConfirmation", "EmailConfirmation"));
                    }
                    else
                    {
                        return LocalRedirect(Url.Action("Index", "SignIn"));
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogWarning(error.Code);
                        if (error.Code == "DuplicateUserName")
                            ModelState.AddModelError("UserName", "Tên đăng nhập này đã tồn tại");
                        else if (error.Code == "DuplicateEmail")
                            ModelState.AddModelError("Email", "Email này đã được đăng ký");
                        else if (error.Code == "PasswordRequiresDigit")
                            ModelState.AddModelError("Password", "Mật khẩu phải có ký tự và số");
                        else if (error.Code == "PasswordRequiresUpper" || error.Code == "PasswordRequiresLower")
                            ModelState.AddModelError("Password", "Mật khẩu phải có ký tự thường và in hoa");
                    }
                }
            }
            return View("Index", Input);
        }

        [HttpGet("SignUp")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}
