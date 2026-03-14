using EcommerceCandyHill.Application.Commands.Product;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Interfaces
{
    public interface IProductAppService
    {
        ValidationResult Save(CreateProductCommand command);
        List<Product> GetAll();
        ValidationResult Update(UpdateProductCommand command);
    }
}
