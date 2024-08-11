using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Entities
{
    internal class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CPF { get; set; }
        public required string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
