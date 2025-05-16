using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.Mediator.Queries.TagQueries;
using MovieApi.Application.Features.Mediator.Results.TagResults;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly MovieApiContext _context;

        public GetTagQueryHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var tags = await _context.Tags.ToListAsync();
            return tags.Select(x => new GetTagQueryResult
            {
                TagId = x.TagId,
                Title = x.Title
            }).ToList();
        }
    }
}
