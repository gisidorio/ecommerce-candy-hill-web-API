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

        public void Deactivate(int id)
        {
            _tagRepository.Deactivate(id);
        }

        public List<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }

        public Tag? GetById(int id)
        {
            return _tagRepository.GetById(id);
        }

        public int Save(Tag tag)
        {
            return _tagRepository.Save(tag);    
        }

        public void Update(Tag tag)
        {
            _tagRepository.Update(tag);
        }
    }
}
