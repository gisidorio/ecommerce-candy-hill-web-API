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
        Guid Save(T entity);

        List<T> GetAll();

        T? GetById(Guid id);

        void Update(T entity);

        void Deactivate(Guid id);
    }
}
