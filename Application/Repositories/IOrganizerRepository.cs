using Application.Constants;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IOrganizerRepository
    {
        Task<Organizer> CreateAsync(Organizer organizer);
        Task<(IEnumerable<Organizer>, int)> GetFilteredAsync(
            string? searchTerm,
            string? sortBy,
            string? sortOrder,
            int page,
            int pageSize);
        Task<IEnumerable<Organizer>> GetAllAsync();
        Task<Organizer?> GetByEmailAsync(string email);
        Task<Organizer?> GetByUserIdAsync(Guid userId);
        Task<Organizer?> GetByIdAsync(Guid id);
        Task<Organizer?> UpdateAsync(
            Guid id,
            string? name,
            string? email,
            string? phoneNumber,
            string? status);
    }
}
