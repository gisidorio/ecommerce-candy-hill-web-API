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
            _paymentMethodRepository.Deactivate(id);
        }

        public List<PaymentMethod> GetAll()
        {
            return _paymentMethodRepository.GetAll();
        }

        public PaymentMethod? GetById(Guid id)
        {
            return _paymentMethodRepository.GetById(id);
        }

        public Guid Save(PaymentMethod paymentMethod)
        {
            return _paymentMethodRepository.Save(paymentMethod);
        }

        public void Update(PaymentMethod paymentMethod)
        {
            _paymentMethodRepository.Update(paymentMethod);
        }
    }
}
