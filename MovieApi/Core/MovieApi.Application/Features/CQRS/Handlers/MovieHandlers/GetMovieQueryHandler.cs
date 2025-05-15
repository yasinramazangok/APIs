using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRS.Results.MovieResults;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly MovieApiContext _context;

        public GetMovieQueryHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var movies = await _context.Movies.ToListAsync();
            return movies.Select(x => new GetMovieQueryResult
            {
                MovieId = x.MovieId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedYear = x.CreatedYear,
                Description = x.Description,
                Duration = x.Duration,
                Rating = x.Rating,
                ReleaseDate = x.ReleaseDate,
                IsAvailable = x.IsAvailable,
                Title = x.Title
            }).ToList();
        }
    }
}
