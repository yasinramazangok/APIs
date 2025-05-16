using MediatR;
using MovieApi.Application.Features.Mediator.Commands.CastCommands;
using MovieApi.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieApiContext _context;

        public RemoveCastCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var cast = await _context.Casts.FindAsync(request.CastId);
            _context.Casts.Remove(cast);
            await _context.SaveChangesAsync();
        }
    }
}
