namespace Application.Features.Discounts.Dtos
{
    public sealed record DiscountDto(
        Guid id,
        string AmountType,
        decimal Amount,
        DateTime ValidFrom,
        DateTime ValidTo,
        DateTime CreatedAt,
        DateTime UpdatedAt);
}
