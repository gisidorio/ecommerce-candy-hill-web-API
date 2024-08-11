using EcommerceCandyHill.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            _productService.GetAll();
            return View();
        }
    }
}
