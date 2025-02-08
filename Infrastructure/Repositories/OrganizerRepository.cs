using Application.Constants;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class OrganizerRepository(AppDbContext dbContext) : IOrganizerRepository
    {
        public async Task<Organizer> CreateAsync(Organizer organizer)
        {
            await dbContext.Organizers.AddAsync(organizer);
            await dbContext.SaveChangesAsync();
            return organizer;
        }

        public async Task<(IEnumerable<Organizer>, int)> GetFilteredAsync(
            string? searchTerm,
            string? sortBy,
            string? sortOrder,
            int page,
            int pageSize)
        {


            var searchTermLower = searchTerm?.ToLower();
            IQueryable<Organizer> organizerQuery = dbContext.Organizers;

            if (!string.IsNullOrWhiteSpace(searchTermLower))
            {
                organizerQuery = organizerQuery.Include(o => o.User)
                .Where(o => o.Name.ToLower().Contains(searchTermLower)
                || o.PhoneNumber.Contains(searchTermLower));
            }

            var totalCount = await organizerQuery.CountAsync();

            Expression<Func<Organizer, object>> sortProperty = GetSortProperty(sortBy);

            organizerQuery = sortOrder?.ToLower() == SortOrder.Ascending ?
                organizerQuery.OrderBy(sortProperty) :
                organizerQuery.OrderByDescending(sortProperty);

            if(page > 0 && pageSize > 0)
            {
                organizerQuery = organizerQuery.Skip(pageSize * (page - 1))
                .Take(pageSize);
            }


            var organizers = await organizerQuery.ToListAsync();

            return (organizers, totalCount);
        }

        private static Expression<Func<Organizer, object>> GetSortProperty(string? sortBy)
        {
            return sortBy switch
            {
                nameof(Organizer.Name) => organizer => organizer.Name,
                nameof(Organizer.Email) => organizer => organizer.Email,
                nameof(Organizer.PhoneNumber) => organizer => organizer.PhoneNumber,
                nameof(Organizer.Status) => organizer => organizer.Status,
                _ => organizer => organizer.CreatedAt,
            };
        }

        public async Task<Organizer?> GetByEmailAsync(string email)
        {
            var organizer = await dbContext.Organizers.FirstOrDefaultAsync(o => o.Email == email);
            return organizer;
        }

        public async Task<Organizer?> GetByUserIdAsync(Guid userId)
        {
            var organizer = await dbContext.Organizers.FindAsync(userId);
            return organizer;
        }

        public async Task<IEnumerable<Organizer>> GetAllAsync()
        {
            return await dbContext.Organizers.OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public Task<Organizer?> GetByIdAsync(Guid id)
        {
            return dbContext.Organizers.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Organizer?> UpdateAsync(Guid id, string? name, string? email, string? phoneNumber, string? status)
        {
            var organizer = dbContext.Organizers.FirstOrDefault(o => o.Id == id);

            if (organizer == null) return null;

            organizer.Name = name ?? organizer.Name;
            organizer.Email = email ?? organizer.Email;
            organizer.PhoneNumber = phoneNumber ?? organizer.PhoneNumber;
            organizer.Status = status ?? organizer.Status;

            await dbContext.SaveChangesAsync();
            return organizer;
        }
    }
}
