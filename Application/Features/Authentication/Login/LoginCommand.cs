using Application.Features.Authentication.Dtos;
using Application.Interfaces;

namespace Application.Features.Authentication.Login
{
    public sealed record LoginCommand(string Email, string Password) : ICommand<AuthenticationResponse>;
    
}
