using EcommerceCandyHill.Application.ProductImages.Queries.DTO;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductImages.Queries
{
    public class ProductImageQueryService : IProductImageQueryService
    {
        private readonly IProductImageDomainService _productImageService;

        public ProductImageQueryService(IProductImageDomainService productImageService)
        {
            _productImageService = productImageService;
        }

        public List<ProductImage> GetAll()
        {
            return _productImageService.GetAll();
        }
    }
}
