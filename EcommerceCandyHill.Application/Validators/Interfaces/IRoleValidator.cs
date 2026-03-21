using EcommerceCandyHill.Application.Roles.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators.Interfaces
{
    public interface IRoleValidator
    {
        ValidationResult Validate(CreateRoleCommand command);
        ValidationResult Validate(UpdateRoleCommand command);
        ValidationResult Validate(DeleteRoleCommand command);
    }
}
