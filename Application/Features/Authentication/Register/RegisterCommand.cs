using Application.Features.Authentication.Dtos;
using Application.Interfaces;

namespace Application.Features.Authentication.Register
{
    public sealed record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber) : ICommand<AuthenticationResponse>;
}
