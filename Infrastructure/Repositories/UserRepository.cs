using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserRole> CreateUserRoleAsync(UserRole userRole)
        {            
            await dbContext.UserRoles.AddAsync(userRole);
            await dbContext.SaveChangesAsync();
            return userRole;
        }

        public async Task<UserToken> CreateUserTokenAsync(UserToken userToken)
        {
            await dbContext.UserTokens.AddAsync(userToken);

            await dbContext.SaveChangesAsync();

            return userToken;
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            var role = await dbContext.Roles.FirstOrDefaultAsync(role => role.Name == roleName);
            return role;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await dbContext.Users.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await dbContext.Users.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<UserToken?> GetUserTokenAsync(string refreshToken)
        {
            return await dbContext.UserTokens.Include(ut => ut.User)
                .ThenInclude(ut => ut.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(ut => ut.Token == refreshToken);
        }

        public async Task<bool> RevokeUserTokensAsync(Guid userId)
        {
            await dbContext.UserTokens.Where(ut => ut.UserId == userId).ExecuteDeleteAsync();
            return true;
        }

        public async Task<UserToken> UpdateUserTokenAsync(Guid id, string refreshToken)
        {
            var userToken = await dbContext.UserTokens
                .FindAsync(id);

            userToken!.Token = refreshToken;
            userToken.ExpiryDate = DateTime.UtcNow.AddDays(7);

            await dbContext.SaveChangesAsync();

            return userToken;
        }
    }
}
