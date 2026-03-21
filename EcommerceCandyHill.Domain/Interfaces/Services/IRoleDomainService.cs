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
        int Save(Role role);
        List<Role> GetAll();
        void Update(Role role);
        void Deactivate(int id);
        Role? GetById(int id);
    }
}

