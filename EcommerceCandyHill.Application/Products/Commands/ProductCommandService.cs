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


        public ValidationResult Save(CreateProductCommand command)
        {
            var validation = _productValidator.Validate(command);

            if (!validation.IsValid)
                return validation;

            var product = new Product
            {
                Name = command.Name,
                Price = command.Price,
                Quantity = command.Quantity,
                Description = command.Description,
                IsActive = command.IsActive
            };

            var productId = _productDomainService.Save(product);

            if (command.TagIds != null && command.TagIds.Any())
            {
                _productDomainService.AddTagsToProduct(productId, command.TagIds);
            }

            return validation;
        }

        public ValidationResult Update(UpdateProductCommand command)
        {
            var validation = _productValidator.Validate(command);

            if (!validation.IsValid)
                return validation;

            var product = _productDomainService.GetById(command.Id);

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

            _productDomainService.Update(productUpdate);

            return validation;
        }

        public ValidationResult Delete(DeleteProductCommand command)
        {            
            var validation = _productValidator.Validate(command);

            var product = _productDomainService.GetById(command.Id);

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

            _productDomainService.Deactivate(command.Id);
            return validation;
        }
    }
}
