using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Entities
{
    public class UserEmployee
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public required string CPF { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required int CompanyId { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
