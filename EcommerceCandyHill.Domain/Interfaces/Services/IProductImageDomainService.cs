using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IProductImageDomainService
    {
        Task<Guid> Save(ProductImage product);
        Task<List<ProductImage>> GetAll();
        Task Update(ProductImage product);
        Task Deactivate(Guid id);
        Task<ProductImage?> GetById(Guid id);
    }
}
