using MovieApi.Application.Features.CQRS.Commands.MovieCommands;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieApiContext _context;

        public UpdateMovieCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handler(UpdateMovieCommand command)
        {
            var movie = await _context.Movies.FindAsync(command.MovieId);
            movie.Rating = command.Rating;
            movie.IsAvailable = command.IsAvailable;
            movie.Duration = command.Duration;
            movie.CoverImageUrl = command.CoverImageUrl;
            movie.CreatedYear = command.CreatedYear;
            movie.Description = command.Description;
            movie.ReleaseDate = command.ReleaseDate;
            movie.Title = command.Title;
            await _context.SaveChangesAsync();
        }
    }
}
