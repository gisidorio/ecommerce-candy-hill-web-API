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
        int Save(ProductImage product);
        List<ProductImage> GetAll();
        void Update(ProductImage product);
        void Deactivate(int id);
        ProductImage? GetById(int id);
    }
}
