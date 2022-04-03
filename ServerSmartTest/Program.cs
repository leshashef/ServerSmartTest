using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using ServerSmartTest.Model.Context;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(connection);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("https://localhost:8080", "https://localhost:8081", "https://localhost:8082").AllowCredentials().AllowAnyHeader().AllowAnyMethod(); ;
    });
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/api/RedirectToRegistration");
               });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    // При включении HTTPS нужно вернуть CookieSecurePolicy.Always
    Secure = CookieSecurePolicy.None,
});
app.UseAuthentication();    // аутентификация
app.UseAuthorization();     // авторизация
app.UseStaticFiles();
app.MapControllers();

app.Run();
