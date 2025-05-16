using MediatR;
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
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieApiContext _context;

        public GetCastByIdQueryHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var cast = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                Biography = cast.Biography,
                CastId = cast.CastId,
                ImageUrl = cast.ImageUrl,
                Name = cast.Name,
                Overview = cast.Overview,
                Surname = cast.Surname,
                Role = cast.Role
            };
        }
    }
}
