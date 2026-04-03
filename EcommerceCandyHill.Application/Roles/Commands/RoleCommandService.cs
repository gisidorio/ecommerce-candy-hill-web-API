using EcommerceCandyHill.Application.Roles.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using EcommerceCandyHill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Roles.Commands
{
    public class RoleCommandService : IRoleCommandService
    {
        private readonly IRoleDomainService _roleDomainService;
        private readonly IRoleValidator _roleValidator;

        public RoleCommandService(IRoleDomainService roleDomainService, IRoleValidator roleValidator)
        {
            _roleDomainService = roleDomainService;
            _roleValidator = roleValidator;
        }

        public ValidationResult Create(CreateRoleCommand command)
        {
            var validation = _roleValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                IsActive = command.IsActive
            };

            _roleDomainService.Save(role);

            return validation;
        }

        public ValidationResult Deactivate(DeleteRoleCommand command)
        {
            var validation = _roleValidator.Validate(command);

            var role = _roleDomainService.GetById(command.Id);

            if (role == null)
            {
                validation.AddError("Papél não encontrado.");
                return validation;
            }
            if (!role.IsActive)
            {
                validation.AddError("O papél já está desativado.");
            }

            if (!validation.IsValid)
                return validation;

            _roleDomainService.Deactivate(command.Id);
            return validation;
        }

        public ValidationResult Update(UpdateRoleCommand command)
        {
            var validation = _roleValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var tag = _roleDomainService.GetById(command.Id);

            if (tag == null)
            {
                validation.AddError("O papél não foi encontrado.");
                return validation;
            }

            var roleUpdate = new Role
            {
                Id = command.Id,
                Name = command.Name,
                IsActive = command.IsActive
            };

            _roleDomainService.Update(roleUpdate);

            return validation;
        }
    }
}
