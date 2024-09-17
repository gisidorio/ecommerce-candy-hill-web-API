using System.ComponentModel.DataAnnotations;

namespace EcommerceCandyHill.MVC.Models.Save
{
    public class ProductSaveModel
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
