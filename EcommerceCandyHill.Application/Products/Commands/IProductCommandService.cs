using EcommerceCandyHill.Application.Products.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Products.Commands
{
    public interface IProductCommandService
    {
        ValidationResult Save(CreateProductCommand command);
        ValidationResult Update(UpdateProductCommand command);
        ValidationResult Delete(DeleteProductCommand command);
    }
}
