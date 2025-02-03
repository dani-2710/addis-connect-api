namespace Application.Features.Authentication.Common
{
    public sealed record TokenResponse(string AccessToken, string RefreshToken);
}
