using ErrorOr;

namespace Domain.Errors
{
    public static class DiscountErrors
    {
        public static Error DiscountNotFound => Error.NotFound("Discount.NotFound", "Discount not found");
    }
}
