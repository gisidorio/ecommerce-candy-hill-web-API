using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Tags.Commands.DTO
{
    public class CreateTagCommand
    {
        public required string Name { get; set; }
        public bool IsActive { get; set; }        
    }
}
