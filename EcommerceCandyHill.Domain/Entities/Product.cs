using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public required decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}
