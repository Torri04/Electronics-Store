using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_MVC_Project.Models;

public class User
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
}