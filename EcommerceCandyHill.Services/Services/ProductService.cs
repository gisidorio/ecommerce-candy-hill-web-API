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
    public class ProductService : IProductApplicationService
    {
        private readonly IProductAppService _productAppService;

        public ProductService(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public List<Produto> GetAll()
        {
            return _productAppService.GetAll();
        }

        public int Save(Produto product)
        {
            return _productAppService.Save(product);
        }
    }
}
