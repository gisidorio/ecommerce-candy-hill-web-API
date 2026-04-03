using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators
{
    public class TagValidator : ITagValidator
    {
        public ValidationResult Validate(CreateTagCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("A tag não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome da tag é obrigatório.");
            }

            return validationResult;
        }

        public ValidationResult Validate(UpdateTagCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("A tag não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome da tag é obrigatório.");
            }

            return validationResult;
        }

        public ValidationResult Validate(DeleteTagCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O objeto de tag não pode ser nulo.");
                return validationResult;
            }

            return validationResult;
        }
    }
}
