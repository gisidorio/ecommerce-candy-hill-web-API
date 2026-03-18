using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Attributes
{
    public class DecimalValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            if (decimal.TryParse(value.ToString(), out _))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("O valor deve ser um número decimal válido.");
        }
    }
}
