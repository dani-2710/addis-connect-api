using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    internal class JwtService(IUserRepository userRepository, IOptions<JwtOptions> options) : IJwtService
    {
        public string GenerateRefreshToken()
        {
            return CreateRefreshToken();
        }

        public string CreateToken(User user)
        {
            var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
               issuer: options.Value.Issuer,
               audience: options.Value.Audience,
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(options.Value.ExpiryMinutes),
               signingCredentials: creds
               );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return token;
        }

        public async Task<UserToken?> ValidateRefreshTokenAsync(string refreshToken)
        {
            var userToken = await userRepository.GetUserTokenAsync(refreshToken);
            if(userToken == null || userToken.ExpiryDate < DateTime.UtcNow) return null;

            return userToken;
        }

        private string CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
