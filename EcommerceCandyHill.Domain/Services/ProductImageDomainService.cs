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
    public class ProductImageDomainService : IProductImageDomainService
    {
        private readonly IProductImageRepository _imageProductRepository;

        public ProductImageDomainService(IProductImageRepository imageProductRepository)
        {
            _imageProductRepository = imageProductRepository;
        }

        public async Task Deactivate(Guid id)
        {
            await _imageProductRepository.DeactivateAsync(id);
        }

        public async Task<List<ProductImage>> GetAll()
        {
            return await _imageProductRepository.GetAllAsync();
        }

        public async Task<ProductImage?> GetById(Guid id)
        {
            return await _imageProductRepository.GetByIdAsync(id);
        }

        public async Task<Guid> Save(ProductImage productImage)
        {
            return await _imageProductRepository.SaveAsync(productImage);
        }

        public async Task Update(ProductImage productImage)
        {
            await _imageProductRepository.UpdateAsync(productImage);
        }
    }
}
