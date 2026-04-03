using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductImages.Commands.DTO
{
    public class UpdateProductImageCommand
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public required string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public bool IsActive { get; set; }
    }
}
