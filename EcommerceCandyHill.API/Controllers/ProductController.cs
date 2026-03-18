using EcommerceCandyHill.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Application.Commands.Product;

namespace EcommerceCandyHill.MVC.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService, IProductValidator productValidator)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productAppService.GetAll();

            if (!products.Any())
                return NoContent();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateProductCommand command)
        {
            var result = _productAppService.Save(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UpdateProductCommand command)
        {

            if (id != command.Id)
                return BadRequest("O id do produto é diferente do id informado na rota.");

            var result = _productAppService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id, DeleteProductCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id do produto é diferente do id informado na rota.");

            var result = _productAppService.Delete(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
