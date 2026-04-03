using EcommerceCandyHill.Application.Roles.Commands;
using EcommerceCandyHill.Application.Roles.Commands.DTO;
using EcommerceCandyHill.Application.Roles.Queries;
using EcommerceCandyHill.Application.Tags.Commands;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleCommandService _roleCommandService;
        private readonly IRoleQueryService _roleQueryService;

        public RoleController(IRoleCommandService roleCommandService, IRoleQueryService roleQueryService)
        {
            _roleCommandService = roleCommandService;
            _roleQueryService = roleQueryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _roleQueryService.GetAll();

            if (!roles.Any())
                return NoContent();

            return Ok(roles);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateRoleCommand command)
        {
            var result = _roleCommandService.Create(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateRoleCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id do papél é diferente do id informado na rota.");

            var result = _roleCommandService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var command = new DeleteRoleCommand { Id = id };

            var result = _roleCommandService.Deactivate(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
