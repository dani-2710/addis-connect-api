using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRespository(AppDbContext dbContext) : ICategoryRepository
    {
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);

            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if(category == null) return null;

            return category;
        }

        public async Task<Category?> UpdateCategoryAsync(Guid id, string? name, string? icon, string? status)
        {
            var category = await dbContext.Categories.FindAsync(id);
            if(category == null) return null;

            category.Name = name ?? category.Name;
            category.Icon = icon ?? category.Icon;
            category.Status = status ?? category.Status;

            await dbContext.SaveChangesAsync();
            return category;

        }
    }
}
