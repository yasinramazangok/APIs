using MovieApi.Application.Features.CQRS.Queries.MovieQueries;
using MovieApi.Application.Features.CQRS.Results.MovieResults;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieApiContext _context;
        public GetMovieByIdQueryHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var movie = await _context.Movies.FindAsync(query.MovieId);
            return new GetMovieByIdQueryResult
            {
                MovieId = movie.MovieId,
                CoverImageUrl = movie.CoverImageUrl,
                CreatedYear = movie.CreatedYear,
                Description = movie.Description,
                Duration = movie.Duration,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
                IsAvailable = movie.IsAvailable,
                Title = movie.Title
            };
        }
    }
}
