using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Products.Queries.DTO
{
    public class GetAllProductsQuery
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
