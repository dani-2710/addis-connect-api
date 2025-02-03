using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(Guid userId);
        Task<User?> GetUserByEmailAsync(string email);

        Task<UserToken> CreateUserTokenAsync(UserToken userToken);
        Task<UserToken> UpdateUserTokenAsync(Guid id, string refreshToken);
        Task<UserToken?> GetUserTokenAsync(string refreshToken);
        Task<bool> RevokeUserTokensAsync(Guid userId);

        Task<UserRole> CreateUserRoleAsync(UserRole userRole);
        Task<Role?> GetRoleByNameAsync(string roleName);
    }
}
