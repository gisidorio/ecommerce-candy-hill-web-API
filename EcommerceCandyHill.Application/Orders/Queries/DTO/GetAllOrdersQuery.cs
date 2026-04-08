using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Orders.Queries.DTO
{
    public class GetAllOrdersQuery
    {
        public Guid Id { get; set; }
        public long OrderNumber { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
