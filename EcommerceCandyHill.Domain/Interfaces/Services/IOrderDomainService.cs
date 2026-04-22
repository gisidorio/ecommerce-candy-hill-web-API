using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IOrderDomainService
    {
        Task<Guid> SaveAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task DeactivateAsync(Guid id);
        Task<Order?> GetByIdAsync(Guid id);
    }
}
