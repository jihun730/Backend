using _0802pro1.Data;
using _0802pro1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// db context 연결
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDBContext>(
    options => options.UseMySql(
        connection,
        ServerVersion.AutoDetect(connection)
        ));
// identity dbcontext 연결
builder.Services.AddIdentity<MyIdentityUser, IdentityRole>(
        // 이메일 인증 안받아도 상관 없는 옵션 추가
        options => options.SignIn.RequireConfirmedAccount = false
    )
    .AddEntityFrameworkStores<MyDBContext>()
    .AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
