using EcommerceCandyHill.Application.Products.Queries.DTO;
using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Products.Queries
{
    public interface IProductQueryService
    {
        Task<List<GetAllProductsQuery>> GetAllAsync();
    }
}
