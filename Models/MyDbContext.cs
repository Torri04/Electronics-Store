using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC_Project.Models;

public class MyDbContext : DbContext
{
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }

    public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
        builder.AddConsole();
    });

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLoggerFactory(loggerFactory);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");

        FakeData.Faking(modelBuilder);
    }
}