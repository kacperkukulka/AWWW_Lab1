using AWWW_Lab1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
    o => o.UseSqlServer(
        configuration.GetConnectionString("Default")
));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();
