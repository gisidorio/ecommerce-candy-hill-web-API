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
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds)
        {
            await _userRepository.AddRolesToUserAsync(userId, roleIds);
        }

        public async Task DeactivateAsync(Guid id)
        {
            await _userRepository.DeactivateAsync(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<Guid> SaveAsync(User user)
        {
            return await _userRepository.SaveAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task UpdateRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds)
        {
            await _userRepository.UpdateRolesToUserAsync(userId, roleIds);
        }
    }
}
