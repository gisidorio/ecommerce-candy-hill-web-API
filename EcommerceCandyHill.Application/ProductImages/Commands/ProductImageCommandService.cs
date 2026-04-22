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

        public async Task<ValidationResult> Create(CreateProductImageCommand command)
        {
            var validation = _productImageValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var productImage = new ProductImage
            {
                Id = Guid.NewGuid(),
                ImageUrl = command.ImageUrl,
                ProductId = command.ProductId,
                IsMain = command.IsMain,
                IsActive = command.IsActive
            };

            await _productImageService.Save(productImage);

            return validation;
        }

        public async Task<ValidationResult> Deactivate(DeleteProductImageCommand command)
        {
            var validation = _productImageValidator.Validate(command);

            var product = await _productImageService.GetById(command.Id);

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

            await _productImageService.Deactivate(command.Id);
            return validation;
        }

        public async Task<ValidationResult> Update(UpdateProductImageCommand command)
        {
            var validation = _productImageValidator.Validate(command);
            
            if (!validation.IsValid)
            {
                return validation;
            }

            var productImage = await _productImageService.GetById(command.Id);

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

            await _productImageService.Update(productImageUpdate);

            return validation;
        }
    }
}
