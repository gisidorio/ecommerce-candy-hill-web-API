using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public required bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
