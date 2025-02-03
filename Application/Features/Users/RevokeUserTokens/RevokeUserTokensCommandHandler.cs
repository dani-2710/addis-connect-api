using Application.Interfaces;
using Application.Repositories;
using Domain.Errors;
using ErrorOr;

namespace Application.Features.Users.RevokeUserTokens
{
    internal sealed class RevokeUserTokensCommandHandler(IUserRepository userRepository, IUserContext userContext) : ICommandHandler<RevokeUserTokensCommand, bool>
    {
        public async Task<ErrorOr<bool>> Handle(RevokeUserTokensCommand request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser()?.Id;
            if (userId == null) return UserErrors.UserUnAuthenticated;

            var isValidUserId = Guid.TryParse(userId, out Guid parsedUserId);

            if (!isValidUserId) return UserErrors.UserUnAuthenticated;

            return await userRepository.RevokeUserTokensAsync(parsedUserId);

        }
    }
}
