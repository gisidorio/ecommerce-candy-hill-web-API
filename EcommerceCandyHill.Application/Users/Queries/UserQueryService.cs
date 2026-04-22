using EcommerceCandyHill.Application.Tags.Queries.DTO;
using EcommerceCandyHill.Application.Users.Queries.DTO;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Users.Queries
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUserDomainService _userDomainService;

        public UserQueryService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public async Task<List<GetAllUsersQuery>> GetAllAsync()
        {
            var users = await _userDomainService.GetAllAsync();
            var userQueries = new List<GetAllUsersQuery>();

            foreach (var user in users)
            {
                var userQuery = new GetAllUsersQuery
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    CreatedAt = user.CreatedAt
                };

                userQueries.Add(userQuery);
            }

            return userQueries;
        }
    }
}
