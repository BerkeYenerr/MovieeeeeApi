using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.MovieQeries;
using MovieApi.Persistence.Context;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler,
            GetMovieQueryHandler getMovieQueryHandler,
            CreateMovieCommandHandler createMovieCommandHandler,
            UpdateMovieCommandHandler updateMovieCommandHandler,
            RemoveMovieCommandHandler removeMovieCommandHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var value = await _getMovieQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPost] 
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Film Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Film Silme İşlemi Başarılı");
        }

        [HttpGet("GetMovie")]

        public async Task<IActionResult> GetMovie(int id)
        {  
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }

       /* [HttpGet("GetRelatedMovie")]

        public async Task<IActionResult> GetRelatedMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }*/

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Film Güncelleme İşlemi Başarılı");
        }

    }
}
