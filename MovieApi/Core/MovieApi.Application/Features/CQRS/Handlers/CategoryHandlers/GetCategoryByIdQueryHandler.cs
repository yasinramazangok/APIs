using MovieApi.Application.Features.CQRS.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRS.Results.CategoryResults;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieApiContext _context;

        public GetCategoryByIdQueryHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var category = await _context.Categories.FindAsync(query.CategoryId);
            return new GetCategoryByIdQueryResult
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
    }
}
