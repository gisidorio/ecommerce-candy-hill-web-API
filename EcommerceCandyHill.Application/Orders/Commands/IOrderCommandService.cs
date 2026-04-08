using EcommerceCandyHill.Application.Orders.Commands.DTO;
using EcommerceCandyHill.Application.PaymentMethods.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Orders.Commands
{
    public interface IOrderCommandService
    {
        ValidationResult Create(CreateOrderCommand command);
        ValidationResult Update(UpdateOrderCommand command);
    }
}
