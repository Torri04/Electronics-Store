using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Core_MVC_Project.Models;

public class User : IdentityUser
{
    [Display(Name = "Họ và tên")]
    [Required(ErrorMessage = "{0} không được để trống")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} phải có độ dài từ {1} đến {2} kí tự")]
    public string? FullName { set; get; }

    [Display(Name = "Địa chỉ")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "{0} phải có độ dài từ {1} đến {2} kí tự")]
    public string? Address { set; get; }

    [Display(Name = "Ngày sinh")]
    [Required(ErrorMessage = "{0} không được để trống")]
    [DataType(DataType.Date)]
    public DateTime Birthday { set; get; }

    [Required(ErrorMessage = "Cam kết chưa được xác nhận")]
    [Display(Name = "Chính sách bảo mật và điều khoản sử dụng")]
    public bool Commitment { get; set; }
}