using EcommerceCandyHill.Application.PaymentMethods.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using EcommerceCandyHill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.PaymentMethods.Commands
{
    public class PaymentMethodCommandService : IPaymentMethodCommandService
    {
        private readonly IPaymentMethodDomainService _paymentMethodDomainService;
        private readonly IPaymentMethodValidator _paymentMethodValidator;

        public PaymentMethodCommandService(IPaymentMethodDomainService paymentMethodDomainService, IPaymentMethodValidator paymentMethodValidator)
        {
            _paymentMethodDomainService = paymentMethodDomainService;
            _paymentMethodValidator = paymentMethodValidator;
        }

        public async Task<ValidationResult> Create(CreatePaymentMethodCommand command)
        {
            var validation = _paymentMethodValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var paymentMethod = new PaymentMethod
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                IsActive = command.IsActive
            };

            await _paymentMethodDomainService.SaveAsync(paymentMethod);

            return validation;
        }

        public async Task<ValidationResult> Deactivate(DeletePaymentMethodCommand command)
        {
            var validation = _paymentMethodValidator.Validate(command);

            var product = await _paymentMethodDomainService.GetByIdAsync(command.Id);
            if (product == null)
            {
                validation.AddError("Forma de pagamento não encontrada.");
                return validation;
            }
            if (!product.IsActive)
            {
                validation.AddError("A forma de pagamento já está desativada.");
            }

            if (!validation.IsValid)
                return validation;

            await _paymentMethodDomainService.DeactivateAsync(command.Id);
            return validation;
        }

        public async Task<ValidationResult> Update(UpdatePaymentMethodCommand command)
        {
            var validation = _paymentMethodValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var tag = await _paymentMethodDomainService.GetByIdAsync(command.Id);

            if (tag == null)
            {
                validation.AddError("A forma de pagamento não foi encontrada.");
                return validation;
            }

            var paymentMethodUpdate = new PaymentMethod
            {
                Id = command.Id,
                Name = command.Name,
                IsActive = command.IsActive
            };

            await _paymentMethodDomainService.UpdateAsync(paymentMethodUpdate);

            return validation;
        }
    }
}
