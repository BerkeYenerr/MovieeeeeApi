using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _contex;

        public UpdateCategoryCommandHandler(MovieContext contex)
        {
            _contex = contex;

        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _contex.Categories.FindAsync(command.CategoryId);
            value.CategoryName = command.CategoryName;
            await _contex.SaveChangesAsync();
        }
    }
}
