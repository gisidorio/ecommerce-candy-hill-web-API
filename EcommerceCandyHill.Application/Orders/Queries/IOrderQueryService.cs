using EcommerceCandyHill.Application.Orders.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Orders.Queries
{
    public interface IOrderQueryService
    {
        Task<List<GetAllOrdersQuery>> GetAllAsync();
    }
}
