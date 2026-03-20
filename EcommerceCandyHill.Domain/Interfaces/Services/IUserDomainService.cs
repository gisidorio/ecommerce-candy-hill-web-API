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
        int Save(User user);
        List<User> GetAll();
        void Update(User user);
        void Deactivate(int id);
        User? GetById(int id);
    }
}
