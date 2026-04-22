using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Users.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Users.Commands
{
    public class UserCommandService : IUserCommandService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IUserValidator _userValidator;

        public UserCommandService(IUserDomainService userDomainService, IUserValidator userValidator)
        {
            _userDomainService = userDomainService;
            _userValidator = userValidator;
        }

        public async Task<ValidationResult> CreateAsync(CreateUserCommand command)
        {
            var validation = _userValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                PasswordHash = command.PasswordHash,
                IsActive = command.IsActive
            };

            var userId = await _userDomainService.SaveAsync(user);

            if (command.RoleIds != null && command.RoleIds.Any())
            {
                await _userDomainService.AddRolesToUserAsync(userId, command.RoleIds);
            }

            return validation;
        }

        public async Task<ValidationResult> DeactivateAsync(DeleteUserCommand command)
        {
            var validation = _userValidator.Validate(command);

            var user = await _userDomainService.GetByIdAsync(command.Id);
            if (user == null)
            {
                validation.AddError("Tag não encontrada.");
                return validation;
            }
            if (!user.IsActive)
            {
                validation.AddError("A tag já está desativada.");
            }

            if (!validation.IsValid)
                return validation;

            await _userDomainService.DeactivateAsync(command.Id);
            return validation;
        }

        public async Task<ValidationResult> UpdateAsync(UpdateUserCommand command)
        {
            var validation = _userValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var user = await _userDomainService.GetByIdAsync(command.Id);

            if (user == null)
            {
                validation.AddError("O usuário não foi encontrada.");
                return validation;
            }

            var userUpdate = new User
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                PasswordHash = command.PasswordHash,
                IsActive = command.IsActive
            };


            if (command.RoleIds != null && command.RoleIds.Any())
            {
                await _userDomainService.UpdateRolesToUserAsync(command.Id, command.RoleIds);
            }

            return validation;
        }
    }
}
