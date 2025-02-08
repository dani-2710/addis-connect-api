using Application.Features.Authentication.Dtos;
using Application.Interfaces;

namespace Application.Features.Admins.RegisterAdmin
{
    public sealed record RegisterAdminCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string PhoneNumber) : ICommand<AuthenticationResponse>;
}
