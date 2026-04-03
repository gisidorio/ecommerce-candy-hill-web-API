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
        void AddRolesToUser(Guid userId, IEnumerable<Guid> roleIds);
        void UpdateRolesToUser(Guid userId, IEnumerable<Guid> roleIds);
    }
}
