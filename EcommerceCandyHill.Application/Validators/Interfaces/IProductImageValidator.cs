using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators.Interfaces
{
    public interface IProductImageValidator
    {
        ValidationResult Validate(CreateProductImageCommand command);
        ValidationResult Validate(UpdateProductImageCommand command);
        ValidationResult Validate(DeleteProductImageCommand command);

    }
}
