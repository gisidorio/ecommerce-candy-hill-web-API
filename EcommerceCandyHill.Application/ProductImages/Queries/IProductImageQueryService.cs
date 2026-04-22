using EcommerceCandyHill.Application.ProductImages.Queries.DTO;
using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductImages.Queries
{
    public interface IProductImageQueryService
    {
        Task<List<GetAllProductImagesQuery>> GetAll();
    }
}
