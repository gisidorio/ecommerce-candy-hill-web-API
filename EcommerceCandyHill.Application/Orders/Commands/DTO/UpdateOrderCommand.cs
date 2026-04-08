using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Orders.Commands.DTO
{
    public class UpdateOrderCommand
    {
        public Guid Id { get; set; }
        public required long OrderNumber { get; set; }
        public required Guid UserId { get; set; }
        public required Guid PaymentMethodId { get; set; }
        public required decimal Total { get; set; }
        public required string Status { get; set; }
        public required IEnumerable<Guid> ProductsIds { get; set; }
    }
}
