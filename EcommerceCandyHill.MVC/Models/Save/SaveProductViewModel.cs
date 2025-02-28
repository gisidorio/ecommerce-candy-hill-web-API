using EcommerceCandyHill.Domain.Attributes;
using EcommerceCandyHill.Domain.Attributes.Dates;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCandyHill.MVC.Models.Save
{
    public class SaveProductViewModel
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string Price { get; set; }

        public required string EAN { get; set; }

        public required DateTime ExpirationDate { get; set; }
    }
}
