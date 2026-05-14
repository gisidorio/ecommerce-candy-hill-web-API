#pragma warning disable SKEXP0110, SKEXP0001, SKEXP0010
using EcommerceCandyHill.Application.AI.DTOs;
using EcommerceCandyHill.Application.AI.Interfaces;
using EcommerceCandyHill.Infra.Data.AI.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Text;

namespace EcommerceCandyHill.Infra.Data.AI
{
    public class SemanticKernelCodeGeneratorService : ICodeGeneratorService
    {
        private readonly Kernel _kernel;

        public SemanticKernelCodeGeneratorService(Kernel kernel)
        {
            _kernel = kernel;
        }

        private ChatCompletionAgent CreateAgent()
        {
            var kernel = _kernel.Clone();

            return new ChatCompletionAgent
            {
                Kernel = kernel,
                Instructions = """
            Você é um gerador de código C# para o projeto EcommerceCandyHill.
            
            GERE APENAS O CÓDIGO SOLICITADO. SEM EXPLICAÇÕES. SEM TEXTO ADICIONAL.
            Retorne SOMENTE os blocos de código, sem markdown, sem explicação.
            
            PADRÕES OBRIGATÓRIOS DO PROJETO:
            
            1. ENTIDADE (Domain/Entities):
            namespace EcommerceCandyHill.Domain.Entities
            {
                public class Product
                {
                    public Guid Id { get; set; }
                    public required string Name { get; set; }
                    public required decimal Price { get; set; }
                    public int Quantity { get; set; }
                    public string? Description { get; set; }
                    public required bool IsActive { get; set; }
                    public DateTime? CreatedAt { get; set; }
                }
            }
            
            2. INTERFACE REPOSITÓRIO (Domain/Interfaces/Repositories):
            namespace EcommerceCandyHill.Domain.Interfaces.Repositories
            {
                public interface IProductRepository : IBaseRepository<Product>
                {
                }
            }
            
            3. INTERFACE DOMAIN SERVICE (Domain/Interfaces/Services):
            namespace EcommerceCandyHill.Domain.Interfaces.Services
            {
                public interface IProductDomainService
                {
                    Task<Guid> SaveAsync(Product product);
                    Task<List<Product>> GetAllAsync();
                    Task UpdateAsync(Product product);
                    Task DeactivateAsync(Guid id);
                    Task<Product?> GetByIdAsync(Guid id);
                }
            }
            
            4. COMMANDS (Application/Products/Commands/DTO):
            namespace EcommerceCandyHill.Application.Products.Commands.DTO
            {
                public class CreateProductCommand
                {
                    public required string Name { get; set; }
                    public required bool IsActive { get; set; }
                }
            }
            
            5. INTERFACE COMMAND SERVICE (Application/Products/Commands):
            namespace EcommerceCandyHill.Application.Products.Commands
            {
                public interface IProductCommandService
                {
                    Task<ValidationResult> SaveAsync(CreateProductCommand command);
                    Task<ValidationResult> UpdateAsync(UpdateProductCommand command);
                    Task<ValidationResult> DeleteAsync(DeleteProductCommand command);
                }
            }
            
            6. COMMAND SERVICE (Application/Products/Commands):
            namespace EcommerceCandyHill.Application.Products.Commands
            {
                public class ProductCommandService : IProductCommandService
                {
                    private readonly IProductDomainService _productDomainService;
                    private readonly IProductValidator _productValidator;
            
                    public ProductCommandService(IProductDomainService productDomainService, IProductValidator productValidator)
                    {
                        _productDomainService = productDomainService;
                        _productValidator = productValidator;
                    }
            
                    public async Task<ValidationResult> SaveAsync(CreateProductCommand command) { ... }
                    public async Task<ValidationResult> UpdateAsync(UpdateProductCommand command) { ... }
                    public async Task<ValidationResult> DeleteAsync(DeleteProductCommand command) { ... }
                }
            }
            
            7. CONTROLLER (API/Controllers):
            namespace EcommerceCandyHill.API.Controllers
            {
                [ApiController]
                [Route("api/[controller]")]
                public class ProductController : ControllerBase
                {
                    private readonly IProductCommandService _productCommandService;
                    private readonly IProductQueryService _productQueryService;
            
                    public ProductController(IProductCommandService productCommandService, IProductQueryService productQueryService)
                    {
                        _productCommandService = productCommandService;
                        _productQueryService = productQueryService;
                    }
            
                    [HttpGet] public async Task<IActionResult> GetAll() { ... }
                    [HttpGet("{id}")] public async Task<IActionResult> GetById(Guid id) { ... }
                    [HttpPost] public async Task<IActionResult> Save([FromBody] CreateProductCommand command) { ... }
                    [HttpPut("{id}")] public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command) { ... }
                    [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) { ... }
                }
            }
            
            REGRAS ABSOLUTAS:
            - NUNCA use DataAnnotations
            - NUNCA crie construtores
            - SEMPRE use Guid para Id
            - SEMPRE use 'required' para obrigatórios
            - SEMPRE inclua DateTime? CreatedAt nas entidades
            - Substitua 'Product' pelo nome da entidade solicitada
            - Gere TODOS os arquivos quando solicitado CRUD completo
            """
            };
        }

        public async Task<GeneratedCodeDTO> GenerateEntityAsync(string entityName, string properties)
        {
            var agent = CreateAgent();
            var chat = new AgentGroupChat();

            chat.AddChatMessage(new ChatMessageContent(AuthorRole.User,
                $"Gere a entidade '{entityName}' com as propriedades: {properties}"));

            var response = new StringBuilder();
            await foreach (var content in chat.InvokeAsync(agent))
            {
                response.Append(content.Content);
            }

            return new GeneratedCodeDTO
            {
                EntityName = entityName,
                GeneratedCode = response.ToString()
            };
        }

        public async Task<GeneratedCodeDTO> GenerateCRUDAsync(string entityName, string properties)
        {
            var agent = CreateAgent();
            var chat = new AgentGroupChat();

            chat.AddChatMessage(new ChatMessageContent(AuthorRole.User,
                $"Gere o CRUD completo para '{entityName}' com as propriedades: {properties}"));

            var response = new StringBuilder();
            await foreach (var content in chat.InvokeAsync(agent))
            {
                response.Append(content.Content);
            }

            return new GeneratedCodeDTO
            {
                EntityName = entityName,
                GeneratedCode = response.ToString()
            };
        }
    }
}
#pragma warning restore SKEXP0110, SKEXP0001, SKEXP0010