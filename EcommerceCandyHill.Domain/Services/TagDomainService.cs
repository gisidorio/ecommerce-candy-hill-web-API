using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Domain.Services
{
    public class TagDomainService : ITagDomainService
    {
        private readonly ITagRepository _tagRepository;

        public TagDomainService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task DeactivateAsync(Guid id)
        {
            await _tagRepository.DeactivateAsync(id);
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _tagRepository.GetAllAsync();
        }

        public async Task<Tag?> GetByIdAsync(Guid id)
        {
            return await _tagRepository.GetByIdAsync(id);
        }

        public async Task<Guid> SaveAsync(Tag tag)
        {
            return await _tagRepository.SaveAsync(tag);    
        }

        public async Task UpdateAsync(Tag tag)
        {
            await _tagRepository.UpdateAsync(tag);
        }
    }
}
