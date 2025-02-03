using Application.Features.Authentication.Common;
using Application.Interfaces;
using Application.Repositories;
using Domain.Errors;
using ErrorOr;

namespace Application.Features.Authentication.RefreshToken
{
    internal sealed class RefreshTokenCommandHandler(IUserRepository userRepository, IJwtService jwtService) : ICommandHandler<RefreshTokenCommand, TokenResponse>
    {
        public async Task<ErrorOr<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var userToken = await jwtService.ValidateRefreshTokenAsync(request.RefreshToken);

            if(userToken == null) return AuthenticationErrors.RefreshTokenExpired;

            var accessToken = jwtService.CreateToken(userToken.User);

            var refreshToken = jwtService.GenerateRefreshToken();
            var updatedUserToken = await userRepository.UpdateUserTokenAsync(userToken.Id, refreshToken);

            return new TokenResponse(accessToken, updatedUserToken.Token);
        }
    }
}
