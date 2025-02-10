using Application.Features.Categories.CreateCategory;
using Application.Features.Categories.GetAllCategories;
using Application.Features.Categories.GetCategoryById;
using Application.Features.Categories.UpdateCategory;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IMediator mediator) : BaseController
    {
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var response = await mediator.Send(command);

            return response.Match(result => Created("", result), Problem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await mediator.Send(new GetAllCategoriesQuery());

            return response.Match(Ok, Problem);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdQuery query)
        {
            var response = await mediator.Send(query);

            return response.Match(Ok, Problem);
        }

        [HttpPost("{id:guid}")]
        public async Task<IActionResult> UpadteCategory([FromRoute] Guid id, [FromBody] UpdateCategoryCommand command)
        {
            command = command with { Id = id };
            var response = await mediator.Send(command);

            return response.Match(Ok, Problem);
        }
    }
}
