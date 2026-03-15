using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Application.Services;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using EcommerceCandyHill.Domain.Interfaces.Services;
using EcommerceCandyHill.Domain.Services;
using EcommerceCandyHill.Infra.Data;
using EcommerceCandyHill.Infra.Data.Repositories;
using EcommerceCandyHill.MVC.Models.Save;
using FluentValidation;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddTransient<IProductAppService, ProductAppService>();
builder.Services.AddTransient<IProductDomainService, ProductDomainService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductValidator, ProductValidator>();
builder.Services.AddTransient<IDbConnectionFactory, SqlConnectionFactory>();
builder.Services.AddSingleton<DatabaseSettings>();

builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy
            .WithOrigins("http://localhost:4200") 
            .AllowAnyHeader()
            .AllowAnyMethod());
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

builder.Configuration.AddEnvironmentVariables();

app.UseCors("AllowAngular");
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseStaticFiles();

app.UseAuthorization();

app.MapFallbackToFile("index.html");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
