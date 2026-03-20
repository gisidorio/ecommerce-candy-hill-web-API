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
        public IActionResult GetAll()
        {
            var users = _userQueryService.GetAll();

            if (!users.Any())
                return NoContent();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateUserCommand command)
        {
            var result = _userCommandService.Create(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id do usuário é diferente do id informado na rota.");

            var result = _userCommandService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };

            var result = _userCommandService.Deactivate(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
