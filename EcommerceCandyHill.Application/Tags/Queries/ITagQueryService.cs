using EcommerceCandyHill.Application.Tags.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Tags.Queries
{
    public interface ITagQueryService
    {
        Task<List<GetAllTagsQuery>> GetAllAsync();
    }
}
