using EcommerceCandyHill.Application.ProductFAQs.Commands;
using EcommerceCandyHill.Application.ProductFAQs.Commands.DTO;
using EcommerceCandyHill.Application.ProductFAQs.Queries;
using EcommerceCandyHill.Application.Tags.Commands;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductFAQController : Controller
    {
        private readonly IProductFAQCommandService _productFAQCommandService;
        private readonly IProductFAQQueryService _productFAQQueryService;

        public ProductFAQController(IProductFAQCommandService productFAQCommandService, IProductFAQQueryService productFAQQueryService)
        {
            _productFAQCommandService = productFAQCommandService;
            _productFAQQueryService = productFAQQueryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tags = _productFAQQueryService.GetAll();

            if (!tags.Any())
                return NoContent();

            return Ok(tags);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateProductFAQCommand command)
        {
            var result = _productFAQCommandService.Create(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateProductFAQCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id da FAQ é diferente do id informado na rota.");

            var result = _productFAQCommandService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var command = new DeleteProductFAQCommand { Id = id };

            var result = _productFAQCommandService.Deactivate(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
