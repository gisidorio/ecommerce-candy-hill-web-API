using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<Guid> SaveAsync(T entity);

        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id);

        Task UpdateAsync(T entity);

        Task DeactivateAsync(Guid id);
    }
}
