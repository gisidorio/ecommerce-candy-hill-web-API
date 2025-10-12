using EcommerceCandyHill.Domain.Attributes;
using EcommerceCandyHill.Domain.Attributes.Dates;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCandyHill.MVC.Models.Save
{
    public class SaveProductViewModel
    {
        public Guid Id { get; set; }

        public required string Nome { get; set; }

        public string? Descricao { get; set; }

        public required string Preco { get; set; }

        public required int Quantidade { get; set; }

        public DateTime? Data_Cadastro { get; set; }
    }
}
