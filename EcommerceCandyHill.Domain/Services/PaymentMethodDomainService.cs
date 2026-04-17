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

        public void Deactivate(Guid id)
        {
            _paymentMethodRepository.DeactivateAsync(id);
        }

        public List<PaymentMethod> GetAll()
        {
            return _paymentMethodRepository.GetAllAsync();
        }

        public PaymentMethod? GetById(Guid id)
        {
            return _paymentMethodRepository.GetByIdAsync(id);
        }

        public Guid Save(PaymentMethod paymentMethod)
        {
            return _paymentMethodRepository.SaveAsync(paymentMethod);
        }

        public void Update(PaymentMethod paymentMethod)
        {
            _paymentMethodRepository.UpdateAsync(paymentMethod);
        }
    }
}
