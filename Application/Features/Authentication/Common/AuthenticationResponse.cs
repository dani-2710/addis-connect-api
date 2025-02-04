namespace Application.Features.Authentication.Common
{
    public sealed record AuthenticationResponse(Guid Id,
        string Name,
        string Email,
        string PhoneNumber,
        string AccessToken,
        string RefreshToken);

}
