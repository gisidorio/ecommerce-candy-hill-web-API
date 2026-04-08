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
        Guid Save(Order order);
        List<Order> GetAll();
        void Update(Order order);
        void Deactivate(Guid id);
        Order? GetById(Guid id);
    }
}
