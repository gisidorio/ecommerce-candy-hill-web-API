using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IProductFAQDomainService
    {
        Task<Guid> SaveAsync(ProductFAQ productFAQ);
        Task<List<ProductFAQ>> GetAllAsync();
        Task UpdateAsync(ProductFAQ productFAQ);
        Task DeactivateAsync(Guid id);
        Task<ProductFAQ?> GetByIdAsync(Guid id);
    }
}
