
using Application.Features.Authentication.Common;
using Application.Interfaces;

namespace Application.Features.Authentication.Login
{
    public sealed record LoginCommand(string Email, string Password) : ICommand<AuthenticationResponse>;
    
}
