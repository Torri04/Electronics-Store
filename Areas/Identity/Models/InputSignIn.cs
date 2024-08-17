using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_MVC_Project.Models;
public class InputSignIn
{
    [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
    [DataType(DataType.Text)]
    [Display(Name = "Tên đăng nhập")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }

    [Display(Name = "Ghi nhớ đăng nhập")]
    public bool Remember { get; set; }
}