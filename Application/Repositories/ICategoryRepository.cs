using Domain.Entities;

namespace Application.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task<Category?> UpdateCategoryAsync(Guid id, string? name, string? icon, string? status);

    }
}
