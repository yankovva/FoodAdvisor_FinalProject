using FoodAdvisor.Data;
using FoodAdvisor.Data.Models;
using FoodAdvisor.Data.Repository;
using FoodAdvisor.Data.Services;
using FoodAdvisor.Data.Services.Interfaces;
using FoodAdvisor.Infrastructure;
using FoodAdvisor.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<FoodAdvisorDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>(options =>
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
          .AddRoles<ApplicationRole>()
          .AddSignInManager<SignInManager<ApplicationUser>>()
          .AddUserManager<UserManager<ApplicationUser>>();

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Identity/Account/Login";
    cfg.LogoutPath = "/Home/Index";
    cfg.ExpireTimeSpan = TimeSpan.FromDays(2);
});



builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);

builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IRestaurantFavouritesService, RestaurantFavouritesService>();
builder.Services.AddScoped<IRecepieService, RecepieService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IRecepieFavouritesService, RecepieFavouritesService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IAccountService, AccountService>();


builder.Services.AddRazorPages();


builder.Services.AddControllersWithViews();

var app = builder.Build();

//Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FoodAdvisorDbContext>();
    DatabaseSeeder.SeedDatabase(context);

}


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
