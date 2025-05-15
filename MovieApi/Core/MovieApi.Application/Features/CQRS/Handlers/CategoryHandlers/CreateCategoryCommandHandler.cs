using MovieApi.Application.Features.CQRS.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieApiContext _context;

        public CreateCategoryCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = command.CategoryName
            });
            await _context.SaveChangesAsync();
        }
    }
}
