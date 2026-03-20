using EcommerceCandyHill.Application.ProductFAQs.Commands;
using EcommerceCandyHill.Application.ProductFAQs.Queries;
using EcommerceCandyHill.Application.ProductImages.Commands;
using EcommerceCandyHill.Application.ProductImages.Queries;
using EcommerceCandyHill.Application.Products.Commands;
using EcommerceCandyHill.Application.Products.Queries;
using EcommerceCandyHill.Application.Tags.Commands;
using EcommerceCandyHill.Application.Tags.Queries;
using EcommerceCandyHill.Application.Users.Commands;
using EcommerceCandyHill.Application.Users.Queries;
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

#region Dependency Injection for Tags

builder.Services.AddTransient<ITagQueryService, TagQueryService>();
builder.Services.AddTransient<ITagCommandService, TagCommandService>();
builder.Services.AddTransient<ITagDomainService, TagDomainService>();
builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<ITagValidator, TagValidator>();

#endregion

#region Dependency Injection for Product FAQs

builder.Services.AddTransient<IProductFAQQueryService, ProductFAQQueryService>();
builder.Services.AddTransient<IProductFAQCommandService, ProductFAQCommandService>();
builder.Services.AddTransient<IProductFAQDomainService, ProductFAQDomainService>();
builder.Services.AddTransient<IProductFAQRepository, ProductFAQRepository>();
builder.Services.AddTransient<IProductFAQValidator, ProductFAQValidator>();

#endregion

#region Dependency Injection for Users

builder.Services.AddTransient<IUserQueryService, UserQueryService>();
builder.Services.AddTransient<IUserCommandService, UserCommandService>();
builder.Services.AddTransient<IUserDomainService, UserDomainService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserValidator, UserValidator>();

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
