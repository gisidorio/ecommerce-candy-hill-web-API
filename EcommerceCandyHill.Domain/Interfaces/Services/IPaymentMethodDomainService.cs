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
        Task<Guid> SaveAsync(PaymentMethod paymentMethod);
        Task<List<PaymentMethod>> GetAllAsync();
        Task UpdateAsync(PaymentMethod paymentMethod);
        Task DeactivateAsync(Guid id);
        Task<PaymentMethod?> GetByIdAsync(Guid id);
    }
}
