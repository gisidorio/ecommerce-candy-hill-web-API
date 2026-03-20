using EcommerceCandyHill.Application.ProductImages.Commands.DTO;
using EcommerceCandyHill.Application.Tags.Commands.DTO;
using EcommerceCandyHill.Application.Validators;
using EcommerceCandyHill.Application.Validators.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Tags.Commands
{
    public class TagCommandService : ITagCommandService
    {
        private readonly ITagDomainService _tagDomainService;
        private readonly ITagValidator _tagValidator;

        public TagCommandService(ITagDomainService tagDomainService, ITagValidator tagValidator)
        {
            _tagDomainService = tagDomainService;
            _tagValidator = tagValidator;
        }

        public ValidationResult Create(CreateTagCommand command)
        {
            var validation = _tagValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var tag = new Tag
            {
                Name = command.Name,
                IsActive = command.IsActive
            };

            _tagDomainService.Save(tag);

            return validation;
        }

        public ValidationResult Deactivate(DeleteTagCommand command)
        {
            var validation = _tagValidator.Validate(command);

            var product = _tagDomainService.GetById(command.Id);

            if (product == null)
            {
                validation.AddError("Tag não encontrada.");
                return validation;
            }
            if (!product.IsActive)
            {
                validation.AddError("A tag já está desativada.");
            }

            if (!validation.IsValid)
                return validation;

            _tagDomainService.Deactivate(command.Id);
            return validation;
        }

        public ValidationResult Update(UpdateTagCommand command)
        {
            var validation = _tagValidator.Validate(command);

            if (!validation.IsValid)
            {
                return validation;
            }

            var tag = _tagDomainService.GetById(command.Id);

            if (tag == null)
            {
                validation.AddError("A tag do produto não foi encontrada.");
                return validation;
            }

            var tagUpdate = new Tag
            {
                Id = command.Id,
                Name = command.Name,
                IsActive = command.IsActive
            };

            _tagDomainService.Update(tagUpdate);

            return validation;
        }
    }
}
