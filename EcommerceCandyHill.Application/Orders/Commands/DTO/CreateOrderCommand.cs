using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Orders.Commands.DTO
{
    public class CreateOrderCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public decimal Total { get; set; }
        public required string Status { get; set; }
        public required List<CreateOrderItemCommand> Items { get; set; }
    }
}
