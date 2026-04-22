using EcommerceCandyHill.Application.Tags.Commands;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Queries;
using EcommerceCandyHill.Application.Users.Commands;
using EcommerceCandyHill.Application.Users.Commands.DTO;
using EcommerceCandyHill.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly IUserCommandService _userCommandService;
        private readonly IUserQueryService _userQueryService;

        public UserController(IUserCommandService userCommandService, IUserQueryService userQueryService)
        {
            _userCommandService = userCommandService;
            _userQueryService = userQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userQueryService.GetAllAsync();

            if (!users.Any())
                return NoContent();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody] CreateUserCommand command)
        {
            var result = await _userCommandService.CreateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id do usuário é diferente do id informado na rota.");

            var result = await _userCommandService.UpdateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var command = new DeleteUserCommand { Id = id };

            var result = await _userCommandService.DeactivateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
