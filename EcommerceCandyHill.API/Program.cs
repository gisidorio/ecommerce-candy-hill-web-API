using EcommerceCandyHill.Application.ProductImages.Commands;
using EcommerceCandyHill.Application.ProductImages.Queries;
using EcommerceCandyHill.Application.Products.Commands;
using EcommerceCandyHill.Application.Products.Queries;
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

#region Dependency Injection for Products

builder.Services.AddTransient<IProductQueryService, ProductQueryService>();
builder.Services.AddTransient<IProductCommandService, ProductCommandService>();
builder.Services.AddTransient<IProductDomainService, ProductDomainService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductValidator, ProductValidator>();

#endregion

#region Dependency Injection for Product Images

builder.Services.AddTransient<IProductImageQueryService, ProductImageQueryService>();
builder.Services.AddTransient<IProductImageCommandService, ProductImageCommandService>();
builder.Services.AddTransient<IProductImageDomainService, ProductImageDomainService>();
builder.Services.AddTransient<IProductImageRepository, ProductImageRepository>();
builder.Services.AddTransient<IProductImageValidator, ProductImageValidator>();

#endregion

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
