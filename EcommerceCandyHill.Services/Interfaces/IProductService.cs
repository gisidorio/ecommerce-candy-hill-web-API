using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Services.Interfaces
{
    public interface IProductService
    {
        int Save(Produto product);
        List<Produto> GetAll();
    }
}
