using Application.Features.Categories.Dtos;
using Application.Interfaces;

namespace Application.Features.Categories.UpdateCategory
{
    public sealed record UpdateCategoryCommand(
        Guid Id,
        string? Name,
        string? Icon,
        string? Status) : ICommand<CategorySingleResponse>;
}
