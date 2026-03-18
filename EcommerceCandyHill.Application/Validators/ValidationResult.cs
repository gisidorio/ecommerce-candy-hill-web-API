using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Validators
{
    public class ValidationResult
    {
        private readonly List<string> _errors = new();

        public IReadOnlyCollection<string> Errors => _errors;

        public bool IsValid => !_errors.Any();

        public string Message => string.Join(" | ", _errors);

        public void AddError(string message)
        {
            _errors.Add(message);
        }
    }
}
