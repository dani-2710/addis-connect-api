using Application.Features.Categories.Dtos;
using Application.Interfaces;

namespace Application.Features.Categories.GetCategoryById
{
    public sealed record GetCategoryByIdQuery(Guid Id) : IQuery<CategorySingleResponse>;
}
