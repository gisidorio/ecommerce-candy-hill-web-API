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
        Guid Save(User user);
        List<User> GetAll();
        void Update(User user);
        void Deactivate(Guid id);
        User? GetById(Guid id);
        void AddRolesToUser(Guid userId, IEnumerable<Guid> roleIds);
        void UpdateRolesToUser(Guid userId, IEnumerable<Guid> roleIds);
    }
}
