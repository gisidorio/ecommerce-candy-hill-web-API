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

        public List<Product> GetAll()
        {
            return _productService.GetAll();
        }
    }
}
