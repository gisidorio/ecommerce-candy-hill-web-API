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

        public void AddRolesToUser(Guid userId, IEnumerable<Guid> roleIds)
        {
            _userRepository.AddRolesToUser(userId, roleIds);
        }

        public void Deactivate(Guid id)
        {
            _userRepository.DeactivateAsync(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAllAsync();
        }

        public User? GetById(Guid id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Guid Save(User user)
        {
            return _userRepository.SaveAsync(user);
        }

        public void Update(User user)
        {
            _userRepository.UpdateAsync(user);
        }

        public void UpdateRolesToUser(Guid userId, IEnumerable<Guid> roleIds)
        {
            _userRepository.UpdateRolesToUser(userId, roleIds);
        }
    }
}
