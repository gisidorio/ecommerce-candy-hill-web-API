using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.AI.DTOs
{
    public class GeneratedCodeDTO
    {
        public string EntityName { get; set; } = string.Empty;
        public string GeneratedCode { get; set; } = string.Empty;
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}
