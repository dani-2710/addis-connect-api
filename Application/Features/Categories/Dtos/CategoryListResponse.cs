namespace Application.Features.Categories.Dtos
{
    public sealed record CategoryListResponse(IEnumerable<CategoryDto> Categories);
}
