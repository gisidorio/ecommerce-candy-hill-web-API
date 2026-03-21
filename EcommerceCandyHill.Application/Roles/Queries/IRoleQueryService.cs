using EcommerceCandyHill.Application.Roles.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Roles.Queries
{
    public interface IRoleQueryService
    {
        List<GetAllRolesQuery> GetAll();
    }
}
