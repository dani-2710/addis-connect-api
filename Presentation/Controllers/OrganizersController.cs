using Application.Features.Organizers.CreateOrganizer;
using Application.Features.Organizers.GetAllOrganizers;
using Application.Features.Organizers.GetFilteredOrganizers;
using Application.Features.Organizers.GetOrganizerById;
using Application.Features.Organizers.UpdateOrganizer;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController(IMediator mediator) : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrganizer(CreateOrganizerCommand command)
        {
            var response = await mediator.Send(command);
            return response.Match(result => Created("", result), Problem);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllOrganizers()
        {
            var response = await mediator.Send(new GetAllOrganizersQuery());
            return response.Match(Ok, Problem);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetAllOrganizers([FromQuery] GetFilteredOrganizersQuery query)
        {
            var response = await mediator.Send(query);
            return response.Match(Ok, Problem);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrganizerById([FromRoute] GetOrganizerByIdQuery query)
        {
            var response = await mediator.Send(query);
            return response.Match(Ok, Problem);
        }

        [HttpPost("{id:guid}/update")]
        public async Task<IActionResult> UpdateOrganizer([FromRoute] Guid id, [FromBody] UpdateOrganizerCommand command)
        {
            command = command with { Id = id };
            var response = await mediator.Send(command);
            return response.Match(Ok, Problem);
        }
    }
}
