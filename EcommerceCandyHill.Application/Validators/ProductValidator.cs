using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCandyHill.Application.Commands.Product;
using EcommerceCandyHill.Application.Validators.Interfaces;

namespace EcommerceCandyHill.Application.Validators
{
    public class ProductValidator : IProductValidator
    {
        public ValidationResult Validate(CreateProductCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O objeto de produto não pode ser nulo.");
                return validationResult;
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome do produto é obrigatório.");
            }
            if (command.Price <= 0)
            {
                validationResult.AddError("O preço do produto deve ser maior que zero.");
            }
            if (command.Quantity < 0)
            {
                validationResult.AddError("A quantidade do produto não pode ser negativa.");
            }

            return validationResult;
        }

        public ValidationResult Validate(UpdateProductCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O objeto de produto não pode ser nulo.");
                return validationResult;
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome do produto é obrigatório.");
            }
            if (command.Price <= 0)
            {
                validationResult.AddError("O preço do produto deve ser maior que zero.");
            }
            if (command.Quantity < 0)
            {
                validationResult.AddError("A quantidade do produto não pode ser negativa.");
            }

            return validationResult;
        }

        public ValidationResult Validate(DeleteProductCommand command)
        {
            var validationResult = new ValidationResult();

            if (command.Id == 0)
                validationResult.AddError("Id do produto é obrigatório.");

            return validationResult;
        }
    }
}
