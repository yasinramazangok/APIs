using MediatR;
using MovieApi.Application.Features.Mediator.Commands.TagCommands;
using MovieApi.Persistence.Contexts;

namespace MovieApi.Application.Features.Mediator.Handlers.TagHandlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly MovieApiContext _context;

        public UpdateTagCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _context.Tags.FindAsync(request.TagId);
            tag.Title = request.Title;
            await _context.SaveChangesAsync();
        }
    }
}