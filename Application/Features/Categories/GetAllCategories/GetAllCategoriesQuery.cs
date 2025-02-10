using Application.Features.Categories.Dtos;
using Application.Interfaces;

namespace Application.Features.Categories.GetAllCategories
{
    public sealed record GetAllCategoriesQuery() : IQuery<CategoryListResponse>;
}
