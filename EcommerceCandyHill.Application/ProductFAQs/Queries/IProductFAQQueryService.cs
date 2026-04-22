using EcommerceCandyHill.Application.ProductFAQs.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductFAQs.Queries
{
    public interface IProductFAQQueryService
    {
        Task<List<GetAllProductFAQsQuery>> GetAllAsync();
    }
}
