using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Roles.Commands.DTO
{
    public class CreateRoleCommand
    {
        public required string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
