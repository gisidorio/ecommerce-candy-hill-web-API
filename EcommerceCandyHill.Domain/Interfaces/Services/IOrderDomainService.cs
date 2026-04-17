using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IOrderDomainService
    {
        Task<Guid> Save(Order order);
        Task<List<Order>> GetAll();
        Task Update(Order order);
        Task Deactivate(Guid id);
        Task<Order?> GetById(Guid id);
    }
}
