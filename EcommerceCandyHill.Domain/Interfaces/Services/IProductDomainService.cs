using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IProductDomainService
    {
        long Save(Product product);
        List<Product> GetAll();
        void Update(Product product);
        void Delete(int id);
        Product? GetById(int id);
    }
}
