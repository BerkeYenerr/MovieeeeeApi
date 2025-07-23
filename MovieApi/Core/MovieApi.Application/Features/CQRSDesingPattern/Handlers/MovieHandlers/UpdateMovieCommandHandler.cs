using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler 
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

    
        public async Task Handle(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            if (value == null)
            {
                throw new NotImplementedException();
            }
            value.Rating = command.Rating;
            value.Status = command.Status;
            value.Duration = command.Duration;
            value.CoverImageUrl = command.CoverImageUrl;
            value.CreatedYear = command.CreatedYear;
            value.Description = command.Description;
            value.ReleaseDate = command.ReleaseDate;
            value.Title = command.Title;
            await _context.SaveChangesAsync();
        }

    }
}
