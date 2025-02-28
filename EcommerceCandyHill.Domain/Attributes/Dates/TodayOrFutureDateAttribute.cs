using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Attributes.Dates
{
    public class TodayOrFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue.Date < DateTime.Today)
                {
                    return new ValidationResult("A data deve ser hoje ou no futuro.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
