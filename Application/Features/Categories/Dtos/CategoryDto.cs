namespace Application.Features.Categories.Dtos
{
    public sealed record CategoryDto(
        Guid Id,
        string Name,
        string Icon,
        string Status,
        DateTime CreatedAt,
        DateTime UpdatedAt);
}
