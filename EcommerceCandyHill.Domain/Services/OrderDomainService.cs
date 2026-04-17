using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Services
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDomainService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Deactivate(Guid id)
        {
            _orderRepository.DeactivateAsync(id);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAllAsync();
        }

        public Order? GetById(Guid id)
        {
            return _orderRepository.GetByIdAsync(id);
        }

        public async Task<Guid> Save(Order order)
        {
            return await _orderRepository.SaveAsync(order);
        }

        public void Update(Order order)
        {
            _orderRepository.UpdateAsync(order);
        }
    }
}
