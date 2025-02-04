using Application.Features.Authentication.Common;
using Application.Interfaces;
using Application.Repositories;
using AutoMapper;
using Domain.Constants;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Authentication.Register
{
    internal sealed class RegisterCommandHandler(IUserRepository userRepository, IJwtService jwtService, IMapper mapper) : ICommandHandler<RegisterCommand, AuthenticationResponse>
    {
        public async Task<ErrorOr<AuthenticationResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await userRepository.GetUserByEmailAsync(request.Email);

            if (existingUser != null) return UserErrors.UserAlreadyExists;
            var user = new User();

            var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = hashedPassword;
            user.PhoneNumber = request.PhoneNumber;

            var role = await userRepository.GetRoleByNameAsync(UserRoles.Customer);

            if (role == null) return RoleErrors.RoleNotFound;

            var createdUser = await userRepository.CreateUserAsync(user);

            await userRepository.CreateUserRoleAsync(new UserRole
            {
                RoleId = role.Id,
                UserId = createdUser.Id,
            });

            var newUser = await userRepository.GetUserByIdAsync(createdUser.Id);

            var accessToken = jwtService.CreateToken(newUser!);
            var refreshToken = jwtService.GenerateRefreshToken();

            await userRepository.CreateUserTokenAsync(new UserToken
            {
                Id = Guid.NewGuid(),
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = newUser!.Id,
            });

            var tokenResponse = new TokenResponse(accessToken, refreshToken);

            return mapper.Map<AuthenticationResponse>((newUser, tokenResponse));
        }
    }
}
