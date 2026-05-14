using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AITestController : ControllerBase
    {
        private readonly Kernel _kernel;

        public AITestController(Kernel kernel)
        {
            _kernel = kernel;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            var result = await _kernel.InvokePromptAsync(
                "Responda apenas: 'Semantic Kernel com Groq funcionando!'"
            );

            return Ok(result.ToString());
        }
    }
}
