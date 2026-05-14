using EcommerceCandyHill.Application.Messaging;
using EcommerceCandyHill.Application.Orders.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Events;
using EcommerceCandyHill.Domain.Interfaces.Services;
using EcommerceCandyHill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Orders.Commands
{
    public class OrderCommandService : IOrderCommandService
    {
        private readonly IOrderDomainService _orderDomainService;
        private readonly IProductDomainService _productDomainService;
        private readonly IOrderValidator _orderValidator;
        private readonly IEventPublisher _eventPublisher;

        public OrderCommandService(IOrderDomainService orderDomainService, 
            IOrderValidator orderValidator,
            IProductDomainService productDomainService,
            IEventPublisher eventPublisher
            )
        {
            _productDomainService = productDomainService;
            _orderDomainService = orderDomainService;
            _orderValidator = orderValidator;
            _eventPublisher = eventPublisher;
        }

        public async Task<ValidationResult> CreateAsync(CreateOrderCommand command)
        {
            var validation = _orderValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = command.UserId,
                PaymentMethodId = command.PaymentMethodId,
                Total = command.Total,
                Status = command.Status
            };


            decimal Total = 0;
            var items = new List<OrderItem>();

            foreach (var item in command.Items)
            {
                var product = await _productDomainService.GetByIdAsync(item.ProductId);

                if (product is null)
                {
                    validation.AddError($"Produto {item.ProductId} não encontrado.");
                    return validation;
                }                

                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    ProductName = product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    Subtotal = product.Price * item.Quantity
                };

                Total += orderItem.Subtotal;
                items.Add(orderItem);
            }            

            if (items.Count() == 0)
            {
                validation.AddError("O pedido deve ter no mínimo um item adicionado");
                return validation;
            }

            if (!validation.IsValid)
                return validation;

            order.Total = Total;
            order.Items = items;

            await _orderDomainService.SaveAsync(order);

            await _eventPublisher.PublishAsync(new OrderCreatedEvent
            {
                OrderId = order.Id,
                UserId = order.UserId,
                Total = order.Total,
                Status = order.Status
            }, "order-created");

            return validation;
        }

        public async Task<ValidationResult> UpdateAsync(UpdateOrderCommand command)
        {
            var validation = _orderValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var order = await _orderDomainService.GetByIdAsync(command.Id);

            if (order == null)
            {
                validation.AddError("A forma de pagamento não foi encontrada.");
                return validation;
            }

            var orderUpdate = new Order
            {
                Id = command.Id,
                OrderNumber = command.OrderNumber,
                UserId = command.UserId,
                PaymentMethodId = command.PaymentMethodId,
                Total = command.Total,
                Status = command.Status
            };

            await _orderDomainService.UpdateAsync(orderUpdate);

            return validation;
        }
    }
}
