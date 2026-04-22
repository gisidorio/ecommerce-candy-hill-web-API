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

        public async Task DeactivateAsync(Guid id)
        {
            await _productFAQRepository.DeactivateAsync(id);
        }

        public async Task<List<ProductFAQ>> GetAllAsync()
        {
            return await _productFAQRepository.GetAllAsync();
        }

        public async Task<ProductFAQ?> GetByIdAsync(Guid id)
        {
            return await _productFAQRepository.GetByIdAsync(id);
        }

        public async Task<Guid> SaveAsync(ProductFAQ productFAQ)
        {
            return await _productFAQRepository.SaveAsync(productFAQ);
        }

        public async Task UpdateAsync(ProductFAQ productFAQ)
        {
            await _productFAQRepository.UpdateAsync(productFAQ);
        }
    }
}
