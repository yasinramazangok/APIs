using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRS.Results.CategoryResults;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieApiContext _context;

        public GetCategoryQueryHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
        }
    }
}
