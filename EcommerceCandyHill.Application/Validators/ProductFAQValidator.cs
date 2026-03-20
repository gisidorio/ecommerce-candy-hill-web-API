using EcommerceCandyHill.Application.ProductFAQs.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators
{
    public class ProductFAQValidator : IProductFAQValidator
    {
        public ValidationResult Validate(CreateProductFAQCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("FAQ não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Question))
            {
                validationResult.AddError("A pergunta é obrigatória.");
            }

            if (string.IsNullOrWhiteSpace(command.Answer))
            {
                validationResult.AddError("A resposta é obrigatória.");
            }

            return validationResult;
        }

        public ValidationResult Validate(UpdateProductFAQCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("FAQ não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Question))
            {
                validationResult.AddError("A pergunta é obrigatória.");
            }

            if (string.IsNullOrWhiteSpace(command.Answer))
            {
                validationResult.AddError("A resposta é obrigatória.");
            }

            return validationResult;
        }

        public ValidationResult Validate(DeleteProductFAQCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O objeto de FAQ não pode ser nulo.");
                return validationResult;
            }

            if (command.Id <= 0)
                validationResult.AddError("O id de FAQ é obrigatório.");

            return validationResult;
        }
    }
}
