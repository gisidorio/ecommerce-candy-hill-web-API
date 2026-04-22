using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IRoleDomainService
    {
        Task<Guid> SaveAsync(Role role);
        Task<List<Role>> GetAllAsync();
        Task UpdateAsync(Role role);
        Task DeactivateAsync(Guid id);
        Task<Role?> GetByIdAsync(Guid id);
    }
}

