using System.ComponentModel.DataAnnotations;

namespace EcommerceCandyHill.MVC.Models.Save
{
    public class SaveProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        [StringLength(70, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatório!")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "O campo EAN é obrigatório!")]
        [StringLength(13, ErrorMessage = "O campo EAN deve ter no mínimo 8 ou no máximo 13 dígitos!")]
        public required string EAN { get; set; }

        public required DateTime ExpirationDate { get; set; }

        public required DateTime? RegistrationDate { get; set; }
    }
}
