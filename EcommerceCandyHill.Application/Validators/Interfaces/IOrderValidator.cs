using EcommerceCandyHill.Application.Orders.Commands.DTO;
using EcommerceCandyHill.Application.PaymentMethods.Commands.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators.Interfaces
{
    public interface IOrderValidator
    {
        ValidationResult Validate(CreateOrderCommand command);
        ValidationResult Validate(UpdateOrderCommand command);
    }
}
