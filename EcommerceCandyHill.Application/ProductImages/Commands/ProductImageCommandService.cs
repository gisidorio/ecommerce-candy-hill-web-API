using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductImages.Commands
{
    public class ProductImageCommandService : IProductImageCommandService
    {
        private readonly IProductImageDomainService _productImageService;
        private readonly IProductImageValidator _productImageValidator; 

        public ProductImageCommandService(IProductImageDomainService productImageDomainService, IProductImageValidator productImageValidator)
        {
            _productImageService = productImageDomainService;
            _productImageValidator = productImageValidator;
        }

        public ValidationResult Create(CreateProductImageCommand command)
        {
            var validation = _productImageValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var productImage = new ProductImage
            {
                ImageUrl = command.ImageUrl,
                ProductId = command.ProductId,
                IsMain = command.IsMain,
                IsActive = command.IsActive
            };

            _productImageService.Save(productImage);

            return validation;
        }

        public ValidationResult Deactivate(DeleteProductImageCommand command)
        {
            var validation = _productImageValidator.Validate(command);

            var product = _productImageService.GetById(command.Id);

            if (product == null)
            {
                validation.AddError("Imagem não encontrada.");
                return validation;
            }
            if (!product.IsActive)
            {
                validation.AddError("Imagem já está desativada.");
            }

            if (!validation.IsValid)
                return validation;

            _productImageService.Deactivate(command.Id);
            return validation;
        }

        public ValidationResult Update(UpdateProductImageCommand command)
        {
            var validation = _productImageValidator.Validate(command);
            
            if (!validation.IsValid)
            {
                return validation;
            }

            var productImage = _productImageService.GetById(command.Id);

            if (productImage == null)
            {
                validation.AddError("Imagem do produto não foi encontrada.");
                return validation;
            }

            var productImageUpdate = new ProductImage
            {
                Id = command.Id,
                ImageUrl = command.ImageUrl,
                ProductId = command.ProductId,
                IsMain = command.IsMain,
                IsActive = command.IsActive
            };

            _productImageService.Update(productImageUpdate);

            return validation;
        }
    }
}
