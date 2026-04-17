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

        public void Deactivate(Guid id)
        {
            _tagRepository.DeactivateAsync(id);
        }

        public List<Tag> GetAll()
        {
            return _tagRepository.GetAllAsync();
        }

        public Tag? GetById(Guid id)
        {
            return _tagRepository.GetByIdAsync(id);
        }

        public Guid Save(Tag tag)
        {
            return _tagRepository.SaveAsync(tag);    
        }

        public void Update(Tag tag)
        {
            _tagRepository.UpdateAsync(tag);
        }
    }
}
