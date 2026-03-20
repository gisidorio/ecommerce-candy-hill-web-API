using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Tags.Commands
{
    public interface ITagCommandService
    {
        ValidationResult Create(CreateTagCommand command);
        ValidationResult Update(UpdateTagCommand command);
        ValidationResult Deactivate(DeleteTagCommand command);
    }
}
