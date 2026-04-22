using EcommerceCandyHill.Application.Orders.Queries.DTO;
using EcommerceCandyHill.Application.PaymentMethods.Queries.DTO;
using EcommerceCandyHill.Domain.Interfaces.Services;
using EcommerceCandyHill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Orders.Queries
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly IOrderDomainService _orderDomainService;

        public OrderQueryService(IOrderDomainService orderDomainService)
        {
            _orderDomainService = orderDomainService;
        }

        public async Task<List<GetAllOrdersQuery>> GetAllAsync()
        {
            var orders = await _orderDomainService.GetAllAsync();
            var ordersQueries = new List<GetAllOrdersQuery>();

            foreach (var order in orders)
            {
                var orderQuery = new GetAllOrdersQuery
                {
                    Id = order.Id,
                    OrderNumber = order.OrderNumber,
                    UserId = order.UserId,
                    PaymentMethodId = order.PaymentMethodId,
                    Total = order.Total,
                    Status = order.Status,
                    CreatedAt = order.CreatedAt
                };

                ordersQueries.Add(orderQuery);
            }

            return ordersQueries;
        }
    }
}
