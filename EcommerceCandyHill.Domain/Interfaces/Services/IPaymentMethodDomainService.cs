using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface IPaymentMethodDomainService
    {
        Guid Save(PaymentMethod paymentMethod);
        List<PaymentMethod> GetAll();
        void Update(PaymentMethod paymentMethod);
        void Deactivate(Guid id);
        PaymentMethod? GetById(Guid id);
    }
}
