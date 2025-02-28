using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Attributes.Dates
{
    public class RangeDateAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public RangeDateAttribute(string minDate, string maxDate)
        {
            _minDate = DateTime.Parse(minDate);
            _maxDate = maxDate.ToLower() == "today" ? DateTime.Today : DateTime.Parse(maxDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date < _minDate || date > _maxDate)
                {
                    return new ValidationResult(ErrorMessage ?? $"A data deve estar entre {_minDate:dd/MM/yyyy} e {_maxDate:dd/MM/yyyy}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
