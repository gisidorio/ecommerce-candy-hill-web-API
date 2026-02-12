using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public int Save(Produto product)
        {
            return _productRepository.Save(product);
        }

        public List<Produto> GetAll() 
        {
            return _productRepository.GetAll();
        }
    }
}
