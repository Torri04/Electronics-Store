using ASP.NET_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Get ConnectionStrings to Database
var configuration = builder.Configuration;
string? connectionStrings = configuration.GetConnectionString("MyDBContext");

// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();
services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionStrings));
services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.Run();
