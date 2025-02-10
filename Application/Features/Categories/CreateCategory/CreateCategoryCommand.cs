using Application.Features.Categories.Dtos;
using Application.Interfaces;

namespace Application.Features.Categories.CreateCategory
{
    public sealed record class CreateCategoryCommand(string Name, string Icon) : ICommand<CategorySingleResponse>;
}
