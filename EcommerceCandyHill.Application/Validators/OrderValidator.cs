using EcommerceCandyHill.Application.Orders.Commands.DTO;
using EcommerceCandyHill.Application.PaymentMethods.Commands.DTO;
using EcommerceCandyHill.Application.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators
{
    public class OrderValidator : IOrderValidator
    {
        public ValidationResult Validate(CreateOrderCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O pedido não pode ser null.");
                return validationResult;
            }

            return validationResult;
        }

        public ValidationResult Validate(UpdateOrderCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O pedido não pode ser null.");
                return validationResult;
            }

            return validationResult;
        }
    }
}
