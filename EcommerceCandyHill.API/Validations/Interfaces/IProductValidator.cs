using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.MVC.Models.Save;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validations.Interfaces
{
    public interface IProductValidator
    {
        ValidationResult Validate(SaveProductViewModel product);
    }
}
