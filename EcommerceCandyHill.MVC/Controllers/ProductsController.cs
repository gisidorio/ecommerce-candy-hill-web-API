using EcommerceCandyHill.Application.Validations.Interfaces;
using EcommerceCandyHill.MVC.Mapper;
using EcommerceCandyHill.MVC.Models.Save;
using EcommerceCandyHill.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductValidator _productValidator;

        public ProductsController(IProductService productService, IProductValidator productValidator)
        {
            _productService = productService;
            _productValidator = productValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SaveProduct(SaveProductViewModel saveProductViewModel)        
        {            
            var validationResult = _productValidator.Validate(saveProductViewModel);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    if (ModelState.TryGetValue(error.PropertyName, out var entry) && entry != null)
                    {
                        entry.Errors.Clear();
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }

                return View(saveProductViewModel);
            }

            var product = ProductMapper.ConvertViewModelToEntity(saveProductViewModel);

            _productService.Save(product);
            return View();
        }
    }    
}
