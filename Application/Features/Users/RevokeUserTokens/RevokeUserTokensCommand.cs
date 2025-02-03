
using Application.Interfaces;

namespace Application.Features.Users.RevokeUserTokens
{
    public sealed record RevokeUserTokensCommand() : ICommand<bool>;
}
