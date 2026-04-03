using EcommerceCandyHill.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Interfaces.Services
{
    public interface ITagDomainService
    {
        Guid Save(Tag tag);
        List<Tag> GetAll();
        void Update(Tag tag);
        void Deactivate(Guid id);
        Tag? GetById(Guid id);
    }
}
