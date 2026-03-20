using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Users.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Users.Commands
{
    public interface IUserCommandService
    {
        ValidationResult Create(CreateUserCommand command);
        ValidationResult Update(UpdateUserCommand command);
        ValidationResult Deactivate(DeleteUserCommand command);
    }
}
