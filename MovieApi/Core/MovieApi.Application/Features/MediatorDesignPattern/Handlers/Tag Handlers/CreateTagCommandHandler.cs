using MediatR;
using MovieApi.Domain.Entities;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.Tag_Handlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly MovieContext _context;
        public CreateTagCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
           await _context.Tags.AddAsync(new Tag
            {
                Title = request.Title
            });
            await _context.SaveChangesAsync();
        }
    }
}
