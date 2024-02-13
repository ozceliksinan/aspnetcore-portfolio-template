using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PortfolioTemplate.Data;
using PortfolioTemplate.Models;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsý ve migration iþlemleri //
builder.Services.AddDbContext<PortfolioDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity Options
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<PortfolioDbContext>();

// Üye Olma Ayarlarý Kiþiselleþtirme
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
});

// Çerez Ayarlarý Kiþiselleþtirme
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index";
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();

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

// Identity
app.UseAuthentication();
// Seet Data
SeedData.TestVerileriniDoldur(app);

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();