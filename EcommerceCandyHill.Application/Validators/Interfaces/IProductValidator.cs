using EcommerceCandyHill.Application.Products.Commands.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators.Interfaces
{
    public interface IProductValidator
    {
        ValidationResult Validate(CreateProductCommand command);
        ValidationResult Validate(UpdateProductCommand command);
        ValidationResult Validate(DeleteProductCommand command);
    }
}
