using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators.Interfaces
{
    public interface ITagValidator
    {
        ValidationResult Validate(CreateTagCommand command);
        ValidationResult Validate(UpdateTagCommand command);
        ValidationResult Validate(DeleteTagCommand command);
    }
}
