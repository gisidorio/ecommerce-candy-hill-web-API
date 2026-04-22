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
    public class PaymentMethodDomainService : IPaymentMethodDomainService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodDomainService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task DeactivateAsync(Guid id)
        {
            await _paymentMethodRepository.DeactivateAsync(id);
        }

        public async Task<List<PaymentMethod>> GetAllAsync()
        {
            return await _paymentMethodRepository.GetAllAsync();
        }

        public async Task<PaymentMethod?> GetByIdAsync(Guid id)
        {
            return await _paymentMethodRepository.GetByIdAsync(id);
        }

        public async Task<Guid> SaveAsync(PaymentMethod paymentMethod)
        {
            return await _paymentMethodRepository.SaveAsync(paymentMethod);
        }

        public async Task UpdateAsync(PaymentMethod paymentMethod)
        {
            await _paymentMethodRepository.UpdateAsync(paymentMethod);
        }
    }
}
