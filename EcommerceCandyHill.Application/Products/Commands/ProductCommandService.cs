using EcommerceCandyHill.Application.Products.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Products.Commands
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly IProductDomainService _productDomainService;
        private readonly IProductValidator _productValidator;

        public ProductCommandService(IProductDomainService productService, IProductValidator productValidator)
        {
            _productDomainService = productService;
            _productValidator = productValidator;
        }


        public async Task<ValidationResult> SaveAsync(CreateProductCommand command)
        {
            var validation = _productValidator.Validate(command);

            if (!validation.IsValid)
                return validation;

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
                Quantity = command.Quantity,
                Description = command.Description,
                IsActive = command.IsActive
            };

            var productId = await _productDomainService.SaveAsync(product);

            if (command.TagIds != null && command.TagIds.Any())
            {
                await _productDomainService.AddTagsToProductAsync(productId, command.TagIds);
            }

            return validation;
        }

        public async Task<ValidationResult> UpdateAsync(UpdateProductCommand command)
        {
            var validation = _productValidator.Validate(command);

            if (!validation.IsValid)
                return validation;

            var product = await _productDomainService.GetByIdAsync(command.Id);

            if (product == null)
            {
                validation.AddError("Produto não encontrado.");
                return validation;
            }

            var productUpdate = new Product
            {
                Id = command.Id,
                Name = command.Name,
                Price = command.Price,
                Quantity = command.Quantity,
                Description = command.Description,
                IsActive = command.IsActive
            };

            await _productDomainService.UpdateAsync(productUpdate);

            return validation;
        }

        public async Task<ValidationResult> DeleteAsync(DeleteProductCommand command)
        {            
            var validation = _productValidator.Validate(command);

            var product = await _productDomainService.GetByIdAsync(command.Id);

            if (product == null)
            {
                validation.AddError("Produto não encontrado.");
                return validation;
            }
            if (!product.IsActive)
            {
                validation.AddError("Produto já está inativo.");
            }

            if (!validation.IsValid)
                return validation;            

            await _productDomainService.DeactivateAsync(command.Id);

            return validation;
        }
    }
}
