using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Users.Commands.DTO;
using EcommerceCandyHill.Application.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators
{
    public class UserValidator : IUserValidator
    {
        public ValidationResult Validate(CreateUserCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O usuário não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome do usuário é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(command.Email))
            {
                validationResult.AddError("O email do usuário é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(command.PasswordHash))
            {
                validationResult.AddError("A senha do usuário é obrigatória.");
            }

            return validationResult;
        }

        public ValidationResult Validate(UpdateUserCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O usuário não pode ser null.");
                return validationResult;
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                validationResult.AddError("O nome do usuário é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(command.Email))
            {
                validationResult.AddError("O email do usuário é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(command.PasswordHash))
            {
                validationResult.AddError("A senha do usuário é obrigatória.");
            }

            return validationResult;
        }

        public ValidationResult Validate(DeleteUserCommand command)
        {
            var validationResult = new ValidationResult();

            if (command == null)
            {
                validationResult.AddError("O objeto de usuário não pode ser nulo.");
                return validationResult;
            }

            if (command.Id <= 0)
                validationResult.AddError("O id do usuário é obrigatório.");

            return validationResult;
        }
    }
}
