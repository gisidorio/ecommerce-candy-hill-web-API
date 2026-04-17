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

        public void Deactivate(Guid id)
        {
            _imageProductRepository.DeactivateAsync(id);
        }

        public List<ProductImage> GetAll()
        {
            return _imageProductRepository.GetAllAsync();
        }

        public ProductImage? GetById(Guid id)
        {
            return _imageProductRepository.GetByIdAsync(id);
        }

        public Guid Save(ProductImage productImage)
        {
            return _imageProductRepository.SaveAsync(productImage);
        }

        public void Update(ProductImage productImage)
        {
            _imageProductRepository.UpdateAsync(productImage);
        }
    }
}
