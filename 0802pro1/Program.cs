using _0802pro1.Data;
using _0802pro1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// db context ����
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDBContext>(
    options => options.UseMySql(
        connection,
        ServerVersion.AutoDetect(connection)
        ));
// identity dbcontext ����
builder.Services.AddIdentity<MyIdentityUser, IdentityRole>(
        // �̸��� ���� �ȹ޾Ƶ� ��� ���� �ɼ� �߰�
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
