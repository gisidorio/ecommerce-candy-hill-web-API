using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IUserDomainService
    {
        Task<Guid> SaveAsync(User user);
        Task<List<User>> GetAllAsync();
        Task UpdateAsync(User user);
        Task DeactivateAsync(Guid id);
        Task<User?> GetByIdAsync(Guid id);
        Task AddRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds);
        Task UpdateRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds);
    }
}
