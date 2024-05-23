using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_MVC_Project.Models;

[Table("Product")]
public class Product
{
    [Key]
    public int ProductID { get; set; }

    [Display(Name = "Tên sản phẩm")]
    [Required(ErrorMessage = "{0} không được để trống")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "{0} phải có độ dài từ {1} đến {2} kí tự")]
    public string? ProductName { get; set; }

    [Display(Name = "Mô tả")]
    [Required(ErrorMessage = "{0} không được để trống")]
    [MinLength(5, ErrorMessage = "{0} phải có độ dài tối thiểu 5 kí tự")]
    public string? Description { get; set; }

    [Display(Name = "Tên sản phẩm")]
    [Required(ErrorMessage = "{0} không được để trống")]
    [Range(0, int.MaxValue, ErrorMessage = "Nhập giá trị từ {1}")]
    public int Price { get; set; }

    [Display(Name = "Số lượng kho")]
    [Required(ErrorMessage = "{0} không được để trống")]
    [Range(0, int.MaxValue, ErrorMessage = "Nhập giá trị từ {1}")]
    public int StockQuantity { get; set; }

    [Display(Name = "Ngày tạo")]
    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public int CategoryID;

    [ForeignKey("CategoryID")]
    public ProductCategory? ProductCategory { get; set; }
}