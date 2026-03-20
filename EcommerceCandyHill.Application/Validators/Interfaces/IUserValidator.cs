using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Users.Commands.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators.Interfaces
{
    public interface IUserValidator
    {
        ValidationResult Validate(CreateUserCommand command);
        ValidationResult Validate(UpdateUserCommand command);
        ValidationResult Validate(DeleteUserCommand command);
    }
}
