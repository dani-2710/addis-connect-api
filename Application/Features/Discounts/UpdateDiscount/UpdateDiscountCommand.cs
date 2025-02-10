using Application.Features.Discounts.Dtos;
using Application.Interfaces;

namespace Application.Features.Discounts.UpdateDiscount
{
    public sealed record UpdateDiscountCommand(
        Guid Id,
        string? AmountType,
        decimal? Amount,
        DateTime? ValidFrom,
        DateTime? ValidTo
        ) : ICommand<DiscountSingleResponse>;
}
