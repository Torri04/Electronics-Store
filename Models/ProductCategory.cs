using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_MVC_Project.Models;

[Table("ProductCategory")]
public class ProductCategory
{
    [Key]
    public int ProductCategoryID { get; set; }

    [Display(Name = "Tên danh mục")]
    [Required(ErrorMessage = "{0} không được để trống")]
    [MaxLength(50, ErrorMessage = "{0} không được quá {1} kí tự")]
    public string? CategoryName { get; set; }

    [Display(Name = "Mô tả ngắn")]
    [Required(ErrorMessage = "{0} không được để trống")]
    [StringLength(250, MinimumLength = 5, ErrorMessage = "{0} phải có độ dài từ {1} đến {2} kí tự")]
    public string? CategoryShortDescription { get; set; }

    public List<Product>? Products { get; set; }
}