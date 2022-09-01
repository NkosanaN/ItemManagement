using Microsoft.EntityFrameworkCore;
using ItemManagementControl.Model;
using ItemManagementControl.Service.Data;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using ItemManagementControl.Service;
using ItemManagementControl.Service.Repositoty.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserManager<ApplicationUser>>();

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder
                        .Configuration
                        .GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IItemRepositoty , ItemRepositoty>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ShopContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
//app.MapRazorPages(); //NB :  needed  for Razor pages for routing i.e Identity 

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
