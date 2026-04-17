using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Services
{
    public class RoleDomainService : IRoleDomainService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleDomainService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void Deactivate(Guid id)
        {
            _roleRepository.DeactivateAsync(id);
        }

        public List<Role> GetAll()
        {
            return _roleRepository.GetAllAsync();
        }

        public Role? GetById(Guid id)
        {
            return _roleRepository.GetByIdAsync(id);
        }

        public Guid Save(Role role)
        {
            return _roleRepository.SaveAsync(role);
        }

        public void Update(Role role)
        {
            _roleRepository.UpdateAsync(role);
        }
    }
}
