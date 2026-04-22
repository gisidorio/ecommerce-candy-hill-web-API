using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task AddRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds);
        Task UpdateRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds);
    }
}
