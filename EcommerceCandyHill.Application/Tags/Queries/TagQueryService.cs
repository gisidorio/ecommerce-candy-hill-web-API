using EcommerceCandyHill.Application.Tags.Queries.DTO;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Tags.Queries
{
    public class TagQueryService : ITagQueryService
    {
        private readonly ITagDomainService _tagDomainService;

        public TagQueryService(ITagDomainService tagDomainService)
        {
            _tagDomainService = tagDomainService;
        }

        public List<GetAllTagsQuery> GetAll()
        {
            var tags = _tagDomainService.GetAll();
            var tagQueries = new List<GetAllTagsQuery>();

            foreach (var tag in tags)
            {
                var tagQuery = new GetAllTagsQuery
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    IsActive = tag.IsActive,
                    CreatedAt = tag.CreatedAt
                };

                tagQueries.Add(tagQuery);
            }

            return tagQueries;
        }
    }
}
