using Application.Features.Discounts.CreateDiscount;
using Application.Features.Discounts.UpdateDiscount;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize(Roles = $"{UserRoles.Organizer},{UserRoles.Admin}")]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController(IMediator mediator) : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {
            var response = await mediator.Send(command);

            return response.Match(result => Created("", result), Problem);
        }

        [HttpPost("{id:guid}/update")]
        public async Task<IActionResult> CreateDiscount([FromRoute] Guid id,[FromBody] UpdateDiscountCommand command)
        {
            command = command with { Id = id };
            var response = await mediator.Send(command);

            return response.Match(Ok, Problem);
        }
    }
}
