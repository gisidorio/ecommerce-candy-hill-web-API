using EcommerceCandyHill.Application.PaymentMethods.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.PaymentMethods.Queries
{
    public interface IPaymentMethodQueryService
    {
        List<GetAllPaymentMethodsQuery> GetAll();
    }
}
