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
        Guid Save(Product product);
        List<Product> GetAll();
        void Update(Product product);
        void Deactivate(Guid id);
        Product? GetById(Guid id);
        void AddTagsToProduct(Guid productId, IEnumerable<Guid> tagIds);
    }
}
