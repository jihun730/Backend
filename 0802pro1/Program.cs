using _0802pro1.Data;
using _0802pro1.Hubs;
using _0802pro1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// test02
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// test02
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://10.10.10.204:5098")
                          .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                      });
});


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


// SignalR 빌더
builder.Services.AddSignalR(options => options.MaximumReceiveMessageSize = 1024 * 1024 * 1024);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();


app.UseRouting();

// test02
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mes}/{action=Index}/{id?}");

app.MapHub<SensorHub>("/sensorhub");
app.MapHub<RailHub>("/railhub");

app.Run("http://10.10.10.204:5098");
