using EcommerceCandyHill.Application.ProductFAQs.Commands.DTO;
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

namespace EcommerceCandyHill.Application.ProductFAQs.Commands
{
    public class ProductFAQCommandService : IProductFAQCommandService
    {
        private readonly IProductFAQDomainService _productFAQDomainService;
        private readonly IProductFAQValidator _productFAQValidator;

        public ProductFAQCommandService(IProductFAQDomainService productFAQDomainService, IProductFAQValidator productFAQValidator)
        {
            _productFAQValidator = productFAQValidator;
            _productFAQDomainService = productFAQDomainService;
        }

        public async Task<ValidationResult> Create(CreateProductFAQCommand command)
        {
            var validation = _productFAQValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var productFAQ = new ProductFAQ
            {
                Id = Guid.NewGuid(),
                ProductId = command.ProductId,
                Question = command.Question,
                Answer = command.Answer,
                IsActive = command.IsActive
            };

            await _productFAQDomainService.SaveAsync(productFAQ);

            return validation;
        }

        public async Task<ValidationResult> Deactivate(DeleteProductFAQCommand command)
        {
            var validation = _productFAQValidator.Validate(command);

            var faq = await _productFAQDomainService.GetByIdAsync(command.Id);

            if (faq == null)
            {
                validation.AddError("FAQ não encontrada.");
                return validation;
            }
            if (!faq.IsActive)
            {
                validation.AddError("A FAQ já está desativada.");
            }

            if (!validation.IsValid)
                return validation;

            await _productFAQDomainService.DeactivateAsync(command.Id);
            return validation;
        }

        public async Task<ValidationResult> Update(UpdateProductFAQCommand command)
        {
            var validation = _productFAQValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var faq = await _productFAQDomainService.GetByIdAsync(command.Id);

            if (faq == null)
            {
                validation.AddError("A FAQ do produto não foi encontrada.");
                return validation;
            }

            var productFAQUpdate = new ProductFAQ
            {
                Id = command.Id,
                Question = command.Question,
                Answer = command.Answer,
                IsActive = command.IsActive
            };

            await _productFAQDomainService.UpdateAsync(productFAQUpdate);

            return validation;
        }
    }
}
