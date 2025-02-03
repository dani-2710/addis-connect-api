using Application.Features.Authentication.Common;
using Application.Interfaces;

namespace Application.Features.Authentication.RefreshToken
{
    public sealed record RefreshTokenCommand(string RefreshToken) : ICommand<TokenResponse>;
}
