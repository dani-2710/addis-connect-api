using Application.Features.Admins.RegisterAdmin;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminsController(IMediator mediator) : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterAdminCommand command)
        {
            var response = await mediator.Send(command);

            return response.Match(result => Created("", result), Problem);
        }
    }
}
