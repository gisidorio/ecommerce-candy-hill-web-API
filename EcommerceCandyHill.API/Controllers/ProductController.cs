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
        public async Task<IActionResult> GetAll()
        {
            var products = await _productQueryService.GetAllAsync();

            if (!products.Any())
                return NoContent();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CreateProductCommand command)
        {
            var result = await _productAppService.SaveAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id do produto é diferente do id informado na rota.");

            var result = await _productAppService.UpdateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };

            var result = await _productAppService.DeleteAsync(command);
            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
