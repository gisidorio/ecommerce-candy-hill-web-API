using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Microsoft.SemanticKernel;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Infra.Data.AI.Plugins
{
    public class CleanArchitecturePlugin
    {
        [KernelFunction("generate_entity")]
        [Description("Gera uma entidade C# seguindo os padrões da Clean Architecture do projeto EcommerceCandyHill")]
        public static string GenerateEntity(
            [Description("Nome da entidade")] string entityName,
            [Description("Propriedades no formato 'Nome:Tipo, Nome:Tipo'")] string properties)
        {
            return "Gere uma entidade C# chamada '" + entityName + "' com as propriedades: " + properties + ".\n\n" +
                    "EXEMPLO CORRETO - copie EXATAMENTE este estilo:\n\n" +
                    "namespace EcommerceCandyHill.Domain.Entities\n" +
                    "{\n" +
                    "    public class Product\n" +
                    "    {\n" +
                    "        public Guid Id { get; set; }\n" +
                    "        public required string Name { get; set; }\n" +
                    "        public required decimal Price { get; set; }\n" +
                    "        public int Quantity { get; set; }\n" +
                    "        public string? Description { get; set; }\n" +
                    "        public required bool IsActive { get; set; }\n" +
                    "        public DateTime? CreatedAt { get; set; }\n" +
                    "    }\n" +
                    "}\n\n" +
                    "PROIBIDO - NUNCA faça isso:\n" +
                    "[Required], [StringLength], [MaxLength] ou qualquer DataAnnotation\n" +
                    "Construtores com parâmetros\n" +
                    "Métodos\n" +
                    "UpdatedAt ou qualquer propriedade que não foi solicitada\n\n" +
                    "OBRIGATÓRIO:\n" +
                    "- Namespace: EcommerceCandyHill.Domain.Entities\n" +
                    "- Id: sempre Guid\n" +
                    "- Propriedades obrigatórias: use 'required' keyword\n" +
                    "- Propriedades string opcionais: use '?'\n" +
                    "- Sempre inclua: public DateTime? CreatedAt { get; set; }\n" +
                    "- Gere APENAS o código, sem explicações";
        }

        [KernelFunction("generate_crud")]
        [Description("Gera o CRUD completo seguindo Clean Architecture")]
        public string GenerateCRUD(
            [Description("Nome da entidade")] string entityName,
            [Description("Propriedades no formato 'Nome:Tipo, Nome:Tipo'")] string properties)
        {
            return "Gere o CRUD completo para a entidade '" + entityName + "' com propriedades: " + properties + ".\n\n" +
                   "Gere os seguintes arquivos seguindo os padrões do projeto EcommerceCandyHill:\n\n" +
                   "1. Domain/Entities/" + entityName + ".cs\n" +
                   "2. Domain/Interfaces/Repositories/I" + entityName + "Repository.cs\n" +
                   "3. Domain/Interfaces/Services/I" + entityName + "DomainService.cs\n" +
                   "4. Application/" + entityName + "s/Commands/DTO/Create" + entityName + "Command.cs\n" +
                   "5. Application/" + entityName + "s/Commands/DTO/Update" + entityName + "Command.cs\n" +
                   "6. Application/" + entityName + "s/Commands/DTO/Delete" + entityName + "Command.cs\n" +
                   "7. Application/" + entityName + "s/Commands/I" + entityName + "CommandService.cs\n" +
                   "8. Application/" + entityName + "s/Commands/" + entityName + "CommandService.cs\n" +
                   "9. API/Controllers/" + entityName + "Controller.cs\n\n" +
                   "Use EXATAMENTE os namespaces do projeto: EcommerceCandyHill.[Camada].[Pasta]";
        }
    }
}
