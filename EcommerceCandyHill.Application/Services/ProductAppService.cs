using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductDomainService _productService;

        public ProductAppService(IProductDomainService productService) 
        {
            _productService = productService;
        }

        public List<Produto> GetAll()
        {
            return _productService.GetAll();
        }

        public int Save(Produto product)
        {
            return _productService.Save(product);
        }
    }
}
