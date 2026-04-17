using EcommerceCandyHill.Application.PaymentMethods.Queries.DTO;
using EcommerceCandyHill.Application.Tags.Queries.DTO;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.PaymentMethods.Queries
{
    public class PaymentMethodQueryService : IPaymentMethodQueryService
    {
        private readonly IPaymentMethodDomainService _paymentMethodDomainService;

        public PaymentMethodQueryService(IPaymentMethodDomainService tagDomainService)
        {
            _paymentMethodDomainService = tagDomainService;
        }

        public async Task<List<GetAllPaymentMethodsQuery>> GetAll()
        {
            var paymentMethods = await _paymentMethodDomainService.GetAllAsync();
            var paymentMethodsQueries = new List<GetAllPaymentMethodsQuery>();

            foreach (var tag in paymentMethods)
            {
                var paymentMethodQuery = new GetAllPaymentMethodsQuery
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    IsActive = tag.IsActive,
                    CreatedAt = tag.CreatedAt
                };

                paymentMethodsQueries.Add(paymentMethodQuery);
            }

            return paymentMethodsQueries;
        }
    }
}
