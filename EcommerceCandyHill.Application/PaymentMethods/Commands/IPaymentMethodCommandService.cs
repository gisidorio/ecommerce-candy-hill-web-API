using EcommerceCandyHill.Application.PaymentMethods.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.PaymentMethods.Commands
{
    public interface IPaymentMethodCommandService
    {
        ValidationResult Create(CreatePaymentMethodCommand command);
        ValidationResult Update(UpdatePaymentMethodCommand command);
        ValidationResult Deactivate(DeletePaymentMethodCommand command);
    }
}
