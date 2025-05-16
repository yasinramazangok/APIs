using MediatR;
using MovieApi.Application.Features.Mediator.Commands.CastCommands;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieApiContext _context;

        public UpdateCastCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var cast = await _context.Casts.FindAsync(request.CastId);
            cast.Surname = request.Surname;
            cast.Overview = request.Overview;
            cast.Biography = request.Biography;
            cast.ImageUrl = request.ImageUrl;
            cast.Name = request.Name;
            cast.Role = request.Role;
            await _context.SaveChangesAsync();
        }
    }
}
