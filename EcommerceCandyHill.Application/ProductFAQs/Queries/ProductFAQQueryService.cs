using EcommerceCandyHill.Application.ProductFAQs.Queries.DTO;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.ProductFAQs.Queries
{
    public class ProductFAQQueryService : IProductFAQQueryService
    {
        private readonly IProductFAQDomainService _productFAQDomainService;

        public ProductFAQQueryService(IProductFAQDomainService productFAQDomainService)
        {
            _productFAQDomainService = productFAQDomainService;
        }

        public async Task<List<GetAllProductFAQsQuery>> GetAllAsync()
        {
            var productFAQs = await _productFAQDomainService.GetAllAsync();
            var productFAQsQueries = new List<GetAllProductFAQsQuery>();

            foreach (var productFAQ in productFAQs)
            {
                var productFAQQuery = new GetAllProductFAQsQuery
                {
                    Id = productFAQ.Id,
                    ProductId = productFAQ.ProductId,
                    Question = productFAQ.Question,
                    Answer = productFAQ.Answer
                };

                productFAQsQueries.Add(productFAQQuery);
            }

            return productFAQsQueries;
        }
    }
}
