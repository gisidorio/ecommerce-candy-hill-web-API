using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductFAQs.Queries.DTO
{
    public class GetAllProductFAQsQuery
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
    }
}
