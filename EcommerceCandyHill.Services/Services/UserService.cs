using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserAppService _userAppService;

        public UserService(IUserAppService userAppService)
        {
            _userAppService = userAppService;                
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Save(User user)
        {
            return _userAppService.Save(user);
        }
    }
}
