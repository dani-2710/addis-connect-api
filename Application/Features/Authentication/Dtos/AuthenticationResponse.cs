using Application.Features.Users.Dtos;

namespace Application.Features.Authentication.Dtos
{
    public sealed record AuthenticationResponse(
        UserDto User,
        string AccessToken,
        string RefreshToken);
}
