using EcommerceCandyHill.Application.ProductFAQs.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductFAQs.Commands
{
    public interface IProductFAQCommandService
    {
        Task<ValidationResult> Create(CreateProductFAQCommand command);
        Task<ValidationResult> Update(UpdateProductFAQCommand command);
        Task<ValidationResult> Deactivate(DeleteProductFAQCommand command);
    }
}
