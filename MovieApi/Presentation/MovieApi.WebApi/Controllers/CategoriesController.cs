using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        

        public CategoriesController(GetCategoryQueryHandler getCategoryQueryHandler,
            GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
            CreateCategoryCommandHandler createCategoryCommandHandler, 
            UpdateCategoryCommandHandler updateCategoryCommandHandler,
            RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]

        public async Task<ActionResult> CategoryList()
        {
            var value = await _getCategoryQueryHandler.Handle();
            return Ok(value);
        }
        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Kategori Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Güncelleme İşlemi Başarılı");
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
    }
    }
