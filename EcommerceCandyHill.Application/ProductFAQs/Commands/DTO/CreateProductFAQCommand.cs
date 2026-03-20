using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductFAQs.Commands.DTO
{
    public class CreateProductFAQCommand
    {
        public int ProductId { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
        public bool IsActive { get; set; }
    }
}
