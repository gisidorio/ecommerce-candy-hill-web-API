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
            _orderRepository.Deactivate(id);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order? GetById(Guid id)
        {
            return _orderRepository.GetById(id);
        }

        public Guid Save(Order order)
        {
            return _orderRepository.Save(order);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }
    }
}
