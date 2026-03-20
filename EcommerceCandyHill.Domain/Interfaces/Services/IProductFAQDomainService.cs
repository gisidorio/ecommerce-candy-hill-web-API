using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IProductFAQDomainService
    {
        int Save(ProductFAQ productFAQ);
        List<ProductFAQ> GetAll();
        void Update(ProductFAQ productFAQ);
        void Deactivate(int id);
        ProductFAQ? GetById(int id);
    }
}
