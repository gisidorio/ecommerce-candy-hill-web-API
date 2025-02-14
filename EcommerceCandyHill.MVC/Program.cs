using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Application.Services;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using EcommerceCandyHill.Domain.Interfaces.Services;
using EcommerceCandyHill.Domain.Services;
using EcommerceCandyHill.Infra.Data.Repositories;
using EcommerceCandyHill.Services.Interfaces;
using EcommerceCandyHill.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductAppService, ProductAppService>();
builder.Services.AddTransient<IProductDomainService, ProductDomainService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "product",
    pattern: "Product/{action=Index}/{id?}",
    defaults: new { controller = "Product" });

app.Run();
