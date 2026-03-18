using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
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

        public ProductImageCommandService(IProductImageDomainService productImageDomainService)
        {
            _productImageService = productImageDomainService;
        }

        public ValidationResult Create(CreateProductImageCommand command)
        {
            var validation = new ValidationResult();
        }

        public ValidationResult Deactivate(int id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(int id, UpdateProductImageCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
