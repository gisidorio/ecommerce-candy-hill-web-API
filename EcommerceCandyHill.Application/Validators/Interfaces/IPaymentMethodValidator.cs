using EcommerceCandyHill.Application.PaymentMethods.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators.Interfaces
{
    public interface IPaymentMethodValidator
    {
        ValidationResult Validate(CreatePaymentMethodCommand command);
        ValidationResult Validate(UpdatePaymentMethodCommand command);
        ValidationResult Validate(DeletePaymentMethodCommand command);
    }
}
