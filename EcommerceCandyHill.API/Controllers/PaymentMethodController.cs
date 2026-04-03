using EcommerceCandyHill.Application.PaymentMethods.Commands;
using EcommerceCandyHill.Application.PaymentMethods.Commands.DTO;
using EcommerceCandyHill.Application.PaymentMethods.Queries;
using EcommerceCandyHill.Application.Tags.Commands;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Queries;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodCommandService _paymentMethodCommandService;
        private readonly IPaymentMethodQueryService _paymentMethodQueryService;

        public PaymentMethodController(IPaymentMethodCommandService paymentMethodCommandService, IPaymentMethodQueryService methodPaymentQueryService)
        {
            _paymentMethodCommandService = paymentMethodCommandService;
            _paymentMethodQueryService = methodPaymentQueryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tags = _paymentMethodQueryService.GetAll();

            if (!tags.Any())
                return NoContent();

            return Ok(tags);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreatePaymentMethodCommand command)
        {
            var result = _paymentMethodCommandService.Create(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdatePaymentMethodCommand command)
        {
            if (id != command.Id)
                return BadRequest("O id da forma de pagamento é diferente do id informado na rota.");

            var result = _paymentMethodCommandService.Update(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var command = new DeletePaymentMethodCommand { Id = id };

            var result = _paymentMethodCommandService.Deactivate(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
