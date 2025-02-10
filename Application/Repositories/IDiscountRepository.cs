using Domain.Entities;

namespace Application.Repositories
{
    public interface IDiscountRepository
    {
        Task<Discount> CreateDiscountAsync(Discount discount);
        Task<Discount?> UpdateDiscountAsync(
            Guid id,
            string? amountType,
            decimal? amount,
            DateTime? ValidFrom,
            DateTime? ValidTo);
    }
}
