using Domain.Entities;

namespace Application.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(User user);
        string GenerateRefreshToken();
        Task<UserToken?> ValidateRefreshTokenAsync(string refreshToken);
    }
}
