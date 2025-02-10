using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class DiscountRepository(AppDbContext dbContext) : IDiscountRepository
    {
        public async Task<Discount> CreateDiscountAsync(Discount discount)
        {
            await dbContext.Discounts.AddAsync(discount);
            await dbContext.SaveChangesAsync();
            return discount;
        }

        public async Task<Discount?> UpdateDiscountAsync(
            Guid id,
            string? amountType,
            decimal? amount,
            DateTime? ValidFrom,
            DateTime? ValidTo)
        {
            var discount = await dbContext.Discounts.FindAsync(id);

            if (discount == null) return null;

            discount.AmountType = amountType ?? discount.AmountType;
            discount.Amount = amount ?? discount.Amount;
            discount.ValidFrom = ValidFrom ?? discount.ValidFrom;
            discount.ValidTo = ValidTo ?? discount.ValidTo;

            await dbContext.SaveChangesAsync();
            return discount;
        }
    }
}
