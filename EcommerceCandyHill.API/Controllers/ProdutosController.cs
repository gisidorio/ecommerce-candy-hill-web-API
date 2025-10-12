using EcommerceCandyHill.Application.Validations.Interfaces;
using EcommerceCandyHill.MVC.Mapper;
using EcommerceCandyHill.MVC.Models.Save;
using EcommerceCandyHill.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.MVC.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductValidator _productValidator;

        public ProdutosController(IProductService productService, IProductValidator productValidator)
        {
            _productService = productService;
            _productValidator = productValidator;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_productService.GetAll());
        }

        [HttpPost]
        public IActionResult SalvarProduto([FromBody] SaveProductViewModel saveProductViewModel)        
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

                return Ok(saveProductViewModel);
            }

            var product = ProductMapper.ConvertViewModelToEntity(saveProductViewModel);

            _productService.Save(product);
            return Ok();
        }
    }    
}
