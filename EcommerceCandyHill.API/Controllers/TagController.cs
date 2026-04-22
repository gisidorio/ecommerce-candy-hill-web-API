using EcommerceCandyHill.Application.ProductImages.Commands;
using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.ProductImages.Queries;
using EcommerceCandyHill.Application.Tags.Commands;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TagController : Controller
    {
        private readonly ITagCommandService _tagCommandService;
        private readonly ITagQueryService _tagQueryService;

        public TagController(ITagCommandService tagCommandService, ITagQueryService tagQueryService)
        {
            _tagCommandService = tagCommandService;
            _tagQueryService = tagQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var tags = await _tagQueryService.GetAllAsync();

            if (!tags.Any())
                return NoContent();

            return Ok(tags);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] CreateTagCommand command)
        {
            var result = await _tagCommandService.CreateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateTagCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id da tag é diferente do id informado na rota.");

            var result = await _tagCommandService.UpdateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var command = new DeleteTagCommand { Id = id };

            var result = await _tagCommandService.DeactivateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
