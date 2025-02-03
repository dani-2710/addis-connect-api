using Application.Features.Authentication.Common;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Authentication.Login
{
    internal sealed class LoginCommandHandler(IUserRepository userRepository, IJwtService jwtService, IMapper mapper) : 
        ICommandHandler<LoginCommand, AuthenticationResponse>
    {
        public async Task<ErrorOr<AuthenticationResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByEmailAsync(request.Email);

            if(user == null) return AuthenticationErrors.InvalidCredentials;

            var verificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, request.Password);
            
            if(verificationResult == PasswordVerificationResult.Failed) return AuthenticationErrors.InvalidCredentials;

            var accessToken = jwtService.CreateToken(user); 
            var refreshToken = jwtService.GenerateRefreshToken();

            await userRepository.CreateUserTokenAsync(new UserToken
            {
                Id = Guid.NewGuid(),
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = user.Id,
            });

            var tokenResponse = new TokenResponse(accessToken, refreshToken);

            return mapper.Map<AuthenticationResponse>((user, tokenResponse));
        }
    }
}
