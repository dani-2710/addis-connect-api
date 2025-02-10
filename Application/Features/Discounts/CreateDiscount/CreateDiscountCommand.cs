using Application.Features.Discounts.Dtos;
using Application.Interfaces;

namespace Application.Features.Discounts.CreateDiscount
{
    public sealed record CreateDiscountCommand(
        string AmountType,
        decimal Amount,
        DateTime ValidFrom,
        DateTime ValidTo) : ICommand<DiscountSingleResponse>;
}
