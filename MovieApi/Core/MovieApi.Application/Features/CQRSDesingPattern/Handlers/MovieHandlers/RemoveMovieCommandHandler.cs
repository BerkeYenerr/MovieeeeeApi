using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _contex;

        public RemoveMovieCommandHandler(MovieContext contex)
        {
            _contex = contex;
        }

        public async Task Handle(RemoveMovieCommand command)
        {
            var value=await _contex.Movies.FindAsync(command.MovieId);
            _contex.Movies.Remove(value);
            await _contex.SaveChangesAsync();   

        }


    }
}
