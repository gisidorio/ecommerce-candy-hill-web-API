using EcommerceCandyHill.Application.AI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCandyHill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodeGeneratorController : ControllerBase
    {
        private readonly ICodeGeneratorService _codeGeneratorService;

        public CodeGeneratorController(ICodeGeneratorService codeGeneratorService)
        {
            _codeGeneratorService = codeGeneratorService;
        }

        [HttpPost("entity")]
        public async Task<IActionResult> GenerateEntity([FromBody] GenerateCodeRequest request)
        {
            var result = await _codeGeneratorService.GenerateEntityAsync(
                request.EntityName,
                request.Properties
            );

            return Ok(result);
        }

        [HttpPost("crud")]
        public async Task<IActionResult> GenerateCRUD([FromBody] GenerateCodeRequest request)
        {
            var result = await _codeGeneratorService.GenerateCRUDAsync(
                request.EntityName,
                request.Properties
            );

            return Ok(result);
        }
    }

    public class GenerateCodeRequest
    {
        public string EntityName { get; set; } = string.Empty;
        public string Properties { get; set; } = string.Empty;
    }
}
