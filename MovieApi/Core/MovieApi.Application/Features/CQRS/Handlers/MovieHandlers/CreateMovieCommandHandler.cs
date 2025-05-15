using MovieApi.Application.Features.CQRS.Commands.MovieCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieApiContext _context;

        public CreateMovieCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Movie
            {
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Duration = command.Duration,
                Rating = command.Rating,
                ReleaseDate = command.ReleaseDate,
                IsAvailable = command.IsAvailable,
                Title = command.Title
            });
            await _context.SaveChangesAsync();
        }
    }
}
