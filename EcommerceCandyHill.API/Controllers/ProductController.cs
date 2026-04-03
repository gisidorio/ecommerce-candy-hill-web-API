using Microsoft.AspNetCore.Mvc;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Application.Products.Commands;
using EcommerceCandyHill.Application.Products.Commands.DTO;
using EcommerceCandyHill.Application.Products.Queries;

namespace EcommerceCandyHill.MVC.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductCommandService _productAppService;
        private readonly IProductQueryService _productQueryService;


        public ProductController(IProductCommandService productAppService, IProductQueryService productQueryService)
        {
            _productAppService = productAppService;
            _productQueryService = productQueryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productQueryService.GetAll();

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
        public IActionResult Update(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id do produto é diferente do id informado na rota.");

            var result = _productAppService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };

            var result = _productAppService.Delete(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
