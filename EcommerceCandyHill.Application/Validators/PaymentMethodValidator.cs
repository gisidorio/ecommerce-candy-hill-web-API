using EcommerceCandyHill.Application.PaymentMethods.Commands.DTO;
using EcommerceCandyHill.Application.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators
{
    public class PaymentMethodValidator : IPaymentMethodValidator
    {
        public ValidationResult Validate(CreatePaymentMethodCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("A forma de pagamento não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome da forma de pagamento é obrigatório.");
            }

            return validationResult;
        }

        public ValidationResult Validate(UpdatePaymentMethodCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("A forma de pagamento não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome da forma de pagamento é obrigatório.");
            }

            return validationResult;
        }

        public ValidationResult Validate(DeletePaymentMethodCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O objeto da forma de pagamento não pode ser nulo.");
                return validationResult;
            }

            return validationResult;
        }
    }
}
