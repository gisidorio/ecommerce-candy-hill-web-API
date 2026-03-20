using EcommerceCandyHill.Application.Users.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Users.Queries
{
    public interface IUserQueryService
    {
        List<GetAllUsersQuery> GetAll();
    }
}
