using EcommerceCandyHill.Application.Orders.Commands;
using EcommerceCandyHill.Application.Orders.Commands.DTO;
using EcommerceCandyHill.Application.Orders.Queries;
using EcommerceCandyHill.Application.Tags.Commands;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderCommandService _orderCommandService;
        private readonly IOrderQueryService _orderQueryService;

        public OrderController(IOrderCommandService orderCommandService, IOrderQueryService orderQueryService)
        {
            _orderCommandService = orderCommandService;
            _orderQueryService = orderQueryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderQueryService.GetAll();

            if (orders.Count() == 0)
                return NoContent();

            return Ok(orders);
        }

        [HttpPost]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> Save([FromBody] CreateOrderCommand command)
        {
            var result = await _orderCommandService.Create(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id do pedido é diferente do id informado na rota.");

            var result = await _orderCommandService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
