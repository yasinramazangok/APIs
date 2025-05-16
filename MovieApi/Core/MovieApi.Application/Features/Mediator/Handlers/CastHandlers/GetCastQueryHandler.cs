using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.Mediator.Queries.CastQueries;
using MovieApi.Application.Features.Mediator.Results.CastResults;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieApiContext _context;

        public GetCastQueryHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var casts = await _context.Casts.ToListAsync();
            return casts.Select(x => new GetCastQueryResult
            {
                Biography = x.Biography,
                CastId = x.CastId,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Overview = x.Overview,
                Surname = x.Surname,
                Role = x.Role
            }).ToList();
        } //AsNoTracking();
    }
}
