using EcommerceCandyHill.Application.ProductFAQs.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators.Interfaces
{
    public interface IProductFAQValidator
    {
        ValidationResult Validate(CreateProductFAQCommand command);
        ValidationResult Validate(UpdateProductFAQCommand command);
        ValidationResult Validate(DeleteProductFAQCommand command);
    }
}
