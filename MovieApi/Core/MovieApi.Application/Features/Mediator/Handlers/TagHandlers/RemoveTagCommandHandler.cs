using MediatR;
using MovieApi.Application.Features.Mediator.Commands.TagCommands;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.Mediator.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {
        private readonly MovieApiContext _context;

        public RemoveTagCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.FindAsync(request.TagId);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }
    }
}
