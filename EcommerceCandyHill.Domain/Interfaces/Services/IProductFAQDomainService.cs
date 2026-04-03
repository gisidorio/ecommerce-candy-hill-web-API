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
        Guid Save(ProductFAQ productFAQ);
        List<ProductFAQ> GetAll();
        void Update(ProductFAQ productFAQ);
        void Deactivate(Guid id);
        ProductFAQ? GetById(Guid id);
    }
}
