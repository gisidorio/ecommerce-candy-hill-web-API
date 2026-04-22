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
        Task<ValidationResult> CreateAsync(CreateTagCommand command);
        Task<ValidationResult> UpdateAsync(UpdateTagCommand command);
        Task<ValidationResult> DeactivateAsync(DeleteTagCommand command);
    }
}
