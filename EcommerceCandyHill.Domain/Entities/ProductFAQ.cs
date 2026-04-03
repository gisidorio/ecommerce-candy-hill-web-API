using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Entities
{
    public class ProductFAQ
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public required string Question { get; set; }
        public required string Answer { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
