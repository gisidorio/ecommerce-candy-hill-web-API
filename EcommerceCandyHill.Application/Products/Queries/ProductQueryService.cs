using EcommerceCandyHill.Application.Products.Queries.DTO;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Products.Queries
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly IProductDomainService _productService;

        public ProductQueryService(IProductDomainService productService)
        {
            _productService = productService;
        }

        public async Task<List<GetAllProductsQuery>> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();

            return products.Select(p => new GetAllProductsQuery
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                Description = p.Description,
                IsActive = p.IsActive
            }).ToList();
        }
    }
}
