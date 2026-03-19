using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators
{
    public class ProductImageValidator : IProductImageValidator
    {
        public ValidationResult Validate(CreateProductImageCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("Imagem do produto não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.ImageUrl))
            {
                validationResult.AddError("A URL da imagem do produto é obrigatória.");
            }

            if (command.ProductId <= 0)
            {
                validationResult.AddError("O ID do produto deve ser um número positivo.");
            }

            return validationResult;
        }

        public ValidationResult Validate(UpdateProductImageCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("Imagem do produto não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.ImageUrl))
            {
                validationResult.AddError("A URL da imagem do produto é obrigatória.");
            }

            if (command.ProductId <= 0)
            {
                validationResult.AddError("O ID do produto deve ser um número positivo.");
            }

            return validationResult;
        }

        public ValidationResult Validate(DeleteProductImageCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O objeto de imagem não pode ser nulo.");
                return validationResult;
            }

            if (command.Id <= 0)
                validationResult.AddError("Id da imagem é obrigatório.");

            return validationResult;
        }
    }
}
