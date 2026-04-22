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
        Task<ValidationResult> Create(CreatePaymentMethodCommand command);
        Task<ValidationResult> Update(UpdatePaymentMethodCommand command);
        Task<ValidationResult> Deactivate(DeletePaymentMethodCommand command);
    }
}
