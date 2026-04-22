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
        Task<Guid> SaveAsync(Tag tag);
        Task<List<Tag>> GetAllAsync();
        Task UpdateAsync(Tag tag);
        Task DeactivateAsync(Guid id);
        Task<Tag?> GetByIdAsync(Guid id);
    }
}
