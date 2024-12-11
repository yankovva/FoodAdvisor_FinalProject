using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository;
using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.Infrastructure;
using FoodAdvisor.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

string adminEmail = builder.Configuration.GetValue<string>("AdminInfo:Email")!;
string adminUsername = builder.Configuration.GetValue<string>("AdminInfo:Username")!;
string adminPassword = builder.Configuration.GetValue<string>("AdminInfo:Password")!;

builder.Services.AddDbContext<FoodAdvisorDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
    options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigits");
    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
    options.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");

    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
    options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");
    options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");
    
    options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireUniqueEmail");
})
          .AddEntityFrameworkStores<FoodAdvisorDbContext>()
          .AddRoles<IdentityRole<Guid>>()
          .AddSignInManager<SignInManager<ApplicationUser>>()
          .AddUserManager<UserManager<ApplicationUser>>();

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Identity/Account/Login";
    cfg.LogoutPath = "/Home/Index";
    cfg.ExpireTimeSpan = TimeSpan.FromDays(2);
});

builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);
builder.Services.RegisterUserDefinedServices(typeof(IBaseService).Assembly);


builder.Services.AddRazorPages();


builder.Services.AddControllersWithViews(cfg =>
{
    cfg.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.SeedAdministrator(adminEmail, adminUsername, adminPassword);
	app.SeedUsers();
	app.SeedDatabase();

}

app.MapControllerRoute(
	name: "Areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
