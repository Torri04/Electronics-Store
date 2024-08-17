using ASP.NET_Core_MVC_Project.Models;
using ASP.NET_Core_MVC_Project.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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

//Add Identity service
services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<MyDbContext>()
        .AddDefaultTokenProviders();

// Truy cập IdentityOptions
services.Configure<IdentityOptions>(options =>
{
    // Thiết lập về Password
    options.Password.RequireDigit = true; // Không bắt phải có số
    options.Password.RequireLowercase = true; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = true; // Không bắt buộc chữ in
    options.Password.RequiredLength = 6; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 3; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

});

// Mail Service
var mailsettings = configuration.GetSection("MailSettings");  // đọc config
services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject
services.AddTransient<IEmailSender, SendMailService>();        // Đăng ký dịch vụ Mail

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

//Add Indentity Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
