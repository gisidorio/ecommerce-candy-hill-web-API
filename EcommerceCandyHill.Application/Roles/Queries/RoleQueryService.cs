using EcommerceCandyHill.Application.Roles.Queries.DTO;
using EcommerceCandyHill.Application.Tags.Queries.DTO;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using EcommerceCandyHill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Roles.Queries
{
    public class RoleQueryService : IRoleQueryService
    {
        private readonly IRoleDomainService _roleDomainService;

        public RoleQueryService(IRoleDomainService roleDomainService)
        {
            _roleDomainService = roleDomainService;
        }

        public List<GetAllRolesQuery> GetAll()
        {
            var roles = _roleDomainService.GetAll();
            var roleQueries = new List<GetAllRolesQuery>();

            foreach (var role in roles)
            {
                var roleQuery = new GetAllRolesQuery
                {
                    Id = role.Id,
                    Name = role.Name,
                    IsActive = role.IsActive,
                    CreatedAt = role.CreatedAt
                };

                roleQueries.Add(roleQuery);
            }

            return roleQueries;
        }
    }
}
