using Application.Features.Authentication.Dtos;
using Application.Interfaces;

namespace Application.Features.Authentication.RefreshToken
{
    public sealed record RefreshTokenCommand(string RefreshToken) : ICommand<TokenDto>;
}
