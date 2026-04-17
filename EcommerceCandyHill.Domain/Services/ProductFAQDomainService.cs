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
    public class ProductFAQDomainService : IProductFAQDomainService
    {
        private readonly IProductFAQRepository _productFAQRepository;

        public ProductFAQDomainService(IProductFAQRepository productFAQRepository)
        {
            _productFAQRepository = productFAQRepository;
        }

        public void Deactivate(Guid id)
        {
            _productFAQRepository.DeactivateAsync(id);
        }

        public List<ProductFAQ> GetAll()
        {
            return _productFAQRepository.GetAllAsync();
        }

        public ProductFAQ? GetById(Guid id)
        {
            return _productFAQRepository.GetByIdAsync(id);
        }

        public Guid Save(ProductFAQ productFAQ)
        {
            return _productFAQRepository.SaveAsync(productFAQ);
        }

        public void Update(ProductFAQ productFAQ)
        {
            _productFAQRepository.UpdateAsync(productFAQ);
        }
    }
}
