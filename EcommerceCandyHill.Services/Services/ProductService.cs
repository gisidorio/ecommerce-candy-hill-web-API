using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductAppService _productAppService;

        public ProductService(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public List<Product> GetAll()
        {
            return _productAppService.GetAll();
        }

        public int Save(Product product)
        {
            return _productAppService.Save(product);
        }
    }
}
