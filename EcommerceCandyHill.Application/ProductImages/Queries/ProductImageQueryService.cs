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

        public async Task<List<GetAllProductImagesQuery>> GetAll()
        {
            var productImages = await _productImageService.GetAll();
            var productsQueries = new List<GetAllProductImagesQuery>();

            foreach (var productImage in productImages) 
            {
                var productImageQuery = new GetAllProductImagesQuery 
                {
                    Id = productImage.Id,
                    ImageUrl = productImage.ImageUrl,                     
                    IsActive = productImage.IsActive, 
                    IsMain = productImage.IsMain, 
                    CreatedAt = productImage.CreatedAt 
                
                };

                productsQueries.Add(productImageQuery);
            }

            return productsQueries;
        }
    }
}
