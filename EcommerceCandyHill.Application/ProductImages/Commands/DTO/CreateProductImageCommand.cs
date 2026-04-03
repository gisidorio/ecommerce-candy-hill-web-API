using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductImages.Commands.DTO
{
    public class CreateProductImageCommand
    {
        public required string ImageUrl { get; set; }
        public Guid ProductId { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }
    }
}
