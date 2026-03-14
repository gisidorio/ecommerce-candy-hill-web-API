using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _userDomainService;

        public UserAppService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;              
        }

        public User GetAll()
        {
            throw new NotImplementedException();
        }

        public int Save(User user)
        {
            return _userDomainService.Save(user);
        }
    }
}
