using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Application.Services;
using EcommerceCandyHill.Application.Validations;
using EcommerceCandyHill.Application.Validations.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using EcommerceCandyHill.Domain.Interfaces.Services;
using EcommerceCandyHill.Domain.Services;
using EcommerceCandyHill.Infra.Data;
using EcommerceCandyHill.Infra.Data.Repositories;
using EcommerceCandyHill.MVC.Models.Save;
using EcommerceCandyHill.Services.Interfaces;
using EcommerceCandyHill.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductAppService, ProductAppService>();
builder.Services.AddTransient<IProductDomainService, ProductDomainService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductValidator, ProductValidator>();
builder.Services.AddTransient<IValidator<SaveProductViewModel>, ProductValidator>();
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

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); 
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
