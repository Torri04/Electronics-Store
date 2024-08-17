using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_MVC_Project.Models;
public class InputSignUp
{
    [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
    [StringLength(25, ErrorMessage = "{0} phải từ {2} ký tự trở lên", MinimumLength = 6)]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "{0} không được chứa các ký tự đặc biệt")]
    [DataType(DataType.Text)]
    [Display(Name = "Tên đăng nhập")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Họ và tên không được để trống")]
    [StringLength(25, ErrorMessage = "{0} phải từ {2} ký tự trở lên", MinimumLength = 3)]
    [DataType(DataType.Text)]
    [Display(Name = "Họ và tên")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [StringLength(30, ErrorMessage = "{0} phải từ {2} ký tự trở lên", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    [Display(Name = "Xác nhận mật khẩu")]
    [Compare("Password", ErrorMessage = "Mật khẩu không giống nhau")]
    public string? ConfirmPassword { get; set; }

    [Range(typeof(bool), "true", "true", ErrorMessage = "Cam kết chưa được xác nhận")]
    [Display(Name = "Chính sách bảo mật và điều khoản sử dụng")]
    public bool Commitment { get; set; } = true;
}
