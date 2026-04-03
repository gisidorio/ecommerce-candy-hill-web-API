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
        public IActionResult GetAll()
        {
            var tags = _tagQueryService.GetAll();

            if (!tags.Any())
                return NoContent();

            return Ok(tags);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateTagCommand command)
        {
            var result = _tagCommandService.Create(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateTagCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id da tag é diferente do id informado na rota.");

            var result = _tagCommandService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var command = new DeleteTagCommand { Id = id };

            var result = _tagCommandService.Deactivate(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
