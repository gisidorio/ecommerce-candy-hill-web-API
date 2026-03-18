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

        public int Save(Product product)
        {
            return _productRepository.Save(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Deactivate(int id)
        {
            _productRepository.Deactivate(id);
        }

        public Product? GetById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
