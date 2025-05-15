using MovieApi.Application.Features.CQRS.Commands.MovieCommands;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieApiContext _context;

        public RemoveMovieCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.MovieId);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
