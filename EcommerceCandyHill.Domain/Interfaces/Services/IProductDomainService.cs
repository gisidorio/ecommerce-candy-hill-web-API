using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IProductDomainService
    {
        Task<Guid> SaveAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task UpdateAsync(Product product);
        Task DeactivateAsync(Guid id);
        Task<Product?> GetByIdAsync(Guid id);
        Task AddTagsToProductAsync(Guid productId, IEnumerable<Guid> tagIds);
    }
}
