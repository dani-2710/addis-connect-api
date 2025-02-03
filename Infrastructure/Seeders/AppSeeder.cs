
using Domain.Constants;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Seeders
{
    internal sealed class AppSeeder(AppDbContext dbContext) : IAppSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Roles.Any())
                {
                    var roles = new List<Role>
                    {
                        new() { Id = Guid.NewGuid(), Name = UserRoles.Customer },
                        new() { Id = Guid.NewGuid(), Name = UserRoles.Organizer },
                        new() { Id = Guid.NewGuid(), Name = UserRoles.Admin },
                    };

                    await dbContext.Roles.AddRangeAsync(roles);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
