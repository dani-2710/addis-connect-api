using Application.Features.Authentication.Login;
using Application.Features.Authentication.RefreshToken;
using Application.Features.Authentication.Register;
using Application.Features.Users.RevokeUserTokens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AuthController(IMediator mediator) : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var response = await mediator.Send(command);

            return response.Match(Ok, Problem);
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var response = await mediator.Send(command);

            return response.Match(result => Created("", result), Problem);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        {
            var response = await mediator.Send(command);

            return response.Match(Ok, Problem);
        }

        [Authorize]
        [HttpPost("revoke-user-tokens")]
        public async Task<IActionResult> RevokeUserTokens()
        {
            var response = await mediator.Send(new RevokeUserTokensCommand());

            return response.Match(result => Ok(result), Problem);
        }
    }
}
