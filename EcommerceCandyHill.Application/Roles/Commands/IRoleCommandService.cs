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
        ValidationResult Create(CreateRoleCommand command);
        ValidationResult Update(UpdateRoleCommand command);
        ValidationResult Deactivate(DeleteRoleCommand command);
    }
}
