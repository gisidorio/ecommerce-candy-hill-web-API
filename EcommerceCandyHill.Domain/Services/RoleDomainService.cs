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

        public async Task DeactivateAsync(Guid id)
        {
            await _roleRepository.DeactivateAsync(id);
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<Guid> SaveAsync(Role role)
        {
            return await _roleRepository.SaveAsync(role);
        }

        public async Task UpdateAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
        }
    }
}
