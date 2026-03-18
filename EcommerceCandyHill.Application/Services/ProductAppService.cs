using EcommerceCandyHill.Application.Commands.Product;
using EcommerceCandyHill.Application.Interfaces;
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

namespace EcommerceCandyHill.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductDomainService _productService;
        private readonly IProductValidator _productValidator;

        public ProductAppService(IProductDomainService productService, IProductValidator productValidator)
        {
            _productService = productService;
            _productValidator = productValidator;
        }

        public List<Product> GetAll()
        {
            return _productService.GetAll();
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

            _productService.Save(product);

            return validation;
        }

        public ValidationResult Update(UpdateProductCommand command)
        {
            var validation = _productValidator.Validate(command);

            if (!validation.IsValid)
                return validation;

            var product = new Product
            {
                Id = command.Id,
                Name = command.Name,
                Price = command.Price,
                Quantity = command.Quantity,
                Description = command.Description,
                IsActive = command.IsActive
            };

            _productService.Update(product);

            return validation;
        }

        public ValidationResult Delete(DeleteProductCommand command)
        {
            var validation = _productValidator.Validate(command);

            if (!validation.IsValid)
                return validation;

            _productService.Delete(command.Id);
            return validation;
        }
    }
}
