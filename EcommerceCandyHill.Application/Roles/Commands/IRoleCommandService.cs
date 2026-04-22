using EcommerceCandyHill.Application.Roles.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Roles.Commands
{
    public interface IRoleCommandService
    {
        Task<ValidationResult> CreateAsync(CreateRoleCommand command);
        Task<ValidationResult> UpdateAsync(UpdateRoleCommand command);
        Task<ValidationResult> DeactivateAsync(DeleteRoleCommand command);
    }
}
