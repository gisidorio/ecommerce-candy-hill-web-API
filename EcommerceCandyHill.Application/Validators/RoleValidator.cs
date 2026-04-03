using EcommerceCandyHill.Application.Roles.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators
{
    public class RoleValidator : IRoleValidator
    {
        public ValidationResult Validate(CreateRoleCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O papél não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome do papél é obrigatório.");
            }

            return validationResult;
        }

        public ValidationResult Validate(UpdateRoleCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O papél não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O papél é obrigatório.");
            }

            return validationResult;
        }

        public ValidationResult Validate(DeleteRoleCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("Papél não pode ser nulo.");
                return validationResult;
            }

            return validationResult;
        }
    }
}
