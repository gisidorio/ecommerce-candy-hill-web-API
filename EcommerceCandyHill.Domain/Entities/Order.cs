using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public long OrderNumber { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public decimal Total { get; set; }
        public required string Status { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public DateTime? CreatedAt { get; set; }
    }
}
