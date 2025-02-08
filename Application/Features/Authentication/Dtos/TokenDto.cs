namespace Application.Features.Authentication.Dtos
{
    public sealed record TokenDto(string AccessToken, string RefreshToken);
}
