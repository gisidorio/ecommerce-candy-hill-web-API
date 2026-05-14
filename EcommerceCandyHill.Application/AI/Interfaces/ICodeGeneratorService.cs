using EcommerceCandyHill.Application.AI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.AI.Interfaces
{
    public interface ICodeGeneratorService
    {
        Task<GeneratedCodeDTO> GenerateEntityAsync(string entityName, string properties);
        Task<GeneratedCodeDTO> GenerateCRUDAsync(string entityName, string properties);
    }
}
