namespace Application.Features.Authentication.Common
{
    public sealed record AuthenticationResponse(Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string AccessToken,
        string RefreshToken);

}
