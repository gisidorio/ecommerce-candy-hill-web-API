using EcommerceCandyHill.Application.ProductImages.Commands;
using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.ProductImages.Queries;
using EcommerceCandyHill.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageCommandService _productImageCommandService;
        private readonly IProductImageQueryService _productImageQueryService;

        public ProductImageController(IProductImageCommandService productImageCommandService, IProductImageQueryService productImageQueryService)
        {
            _productImageCommandService = productImageCommandService;
            _productImageQueryService = productImageQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productImageQueryService.GetAll();

            if (!products.Any())
                return NoContent();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CreateProductImageCommand command)
        {
            var result = await _productImageCommandService.Create(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductImageCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id da imagem é diferente do id informado na rota.");

            var result = await _productImageCommandService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductImageCommand { Id = id };

            var result = await _productImageCommandService.Deactivate(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
