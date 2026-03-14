using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        long Save(T product);

        List<T> GetAll();

        T? GetById(int id);

        void Update(Product product);

        void Delete(long id);
    }
}
