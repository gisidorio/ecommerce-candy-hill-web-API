using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductImages.Commands
{
    public interface IProductImageCommandService
    {
        ValidationResult Create(CreateProductImageCommand command);
        ValidationResult Update(int id, UpdateProductImageCommand command);
        ValidationResult Deactivate(int id);
    }
}
