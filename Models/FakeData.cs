using Bogus;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC_Project.Models;

public static class FakeData
{
    //ProductCategory
    public static Faker<ProductCategory> ProductCategoryFaker = new Faker<ProductCategory>();
    public static List<ProductCategory>? ProductCategories { get; set; }

    //Product
    public static Faker<Product> ProductFaker = new Faker<Product>();
    public static List<Product>? Products { get; set; }

    public static void Faking(ModelBuilder modelBuilder)
    {
        var ProductCategoryID = 1;
        ProductCategories = ProductCategoryFaker
                            .StrictMode(false)
                            .UseSeed(1122)
                            .RuleFor(x => x.ProductCategoryID, f => ProductCategoryID++)
                            .RuleFor(x => x.CategoryName, f => f.Lorem.Sentence(1))
                            .RuleFor(x => x.CategoryShortDescription, f => f.Lorem.Paragraph(1))
                            .Generate(10);
        modelBuilder.Entity<ProductCategory>().HasData(ProductCategories);

        var ProductID = 1;
        Products = ProductFaker
                            .StrictMode(false)
                            .UseSeed(2233)
                            .RuleFor(x => x.ProductID, f => ProductID++)
                            .RuleFor(x => x.ProductName, f => f.Lorem.Sentence(1))
                            .RuleFor(x => x.Description, f => f.Lorem.Paragraph(3))
                            .RuleFor(x => x.Price, f => f.Random.Number(0, int.MaxValue))
                            .RuleFor(x => x.StockQuantity, f => f.Random.Number(0, int.MaxValue))
                            .RuleFor(x => x.CategoryID, f => f.PickRandom(ProductCategories).ProductCategoryID)
                            .Generate(50);
        modelBuilder.Entity<Product>().HasData(Products);
    }

}