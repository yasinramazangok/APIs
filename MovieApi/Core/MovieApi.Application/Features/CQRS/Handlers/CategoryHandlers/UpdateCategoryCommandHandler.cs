using MovieApi.Application.Features.CQRS.Commands.CategoryCommands;
using MovieApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieApiContext _context;

        public UpdateCategoryCommandHandler(MovieApiContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.CategoryId);
            category.CategoryName = command.CategoryName;
            await _context.SaveChangesAsync();
        }
    }
}
