using MediatR;
using MovieApi.Application.Features.Mediator.Queries.TagQueries;
using MovieApi.Application.Features.Mediator.Results.CastResults;
using MovieApi.Application.Features.Mediator.Results.TagResults;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly MovieApiContext _context;

        public GetTagByIdQueryHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.FindAsync(request.TagId);
            return new GetTagByIdQueryResult
            {
                Title = tag.Title
            };
        }
    }
}