using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.UserRegisterHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.UserRegisterCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _createuserRegisterCommandHandler;

        public RegistersController(CreateUserRegisterCommandHandler createuserRegisterCommandHandler)
        {
            _createuserRegisterCommandHandler = createuserRegisterCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRegister(CreateUserRegisterCommand command)
        {
            await _createuserRegisterCommandHandler.Handle(command);
            return Ok("Kullanıcı başarıyla eklendi");
        }
    }
}
