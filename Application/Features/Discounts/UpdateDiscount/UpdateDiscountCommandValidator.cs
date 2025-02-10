using Domain.Constants;
using FluentValidation;
using System.Globalization;

namespace Application.Features.Discounts.UpdateDiscount
{
    internal sealed class UpdateDiscountCommandValidator : AbstractValidator<UpdateDiscountCommand>
    {
        string[] allowedDiscountAmountTypes = [DiscountAmountTypes.Percentage, DiscountAmountTypes.Fixed];

        public UpdateDiscountCommandValidator()
        {
            RuleFor(command => command.AmountType)
                .Must(value => allowedDiscountAmountTypes.Contains(value))
                .WithMessage($"AmountType must be in [{string.Join(",", allowedDiscountAmountTypes)}]")
                .When(command => command.AmountType != null);

            RuleFor(command => command.Amount)
                .Must(NotBeNaN)
                .WithMessage("Invalid Amount")
                .LessThanOrEqualTo(100)
                .When(command => command.AmountType == DiscountAmountTypes.Percentage)
                .WithMessage("Amount must be in [0,100]")
                .GreaterThan(0)
                .When(command => command.Amount != null);

            RuleFor(command => command.ValidFrom)
                .Must(BeInTheFuture)
                .WithMessage("ValidFrom must be in the future")
                .LessThan(command => command.ValidTo)
                .WithMessage("ValidFrom must be less than ValidTo")
                .When(command => command.ValidFrom.HasValue)
                .NotNull()
                .WithMessage("ValidFrom is required when ValidTo is provided.")
                .When(x => x.ValidTo.HasValue);

            RuleFor(command => command.ValidTo)
                .Must(BeInTheFuture)
                .WithMessage("ValidFrom must be in the future")
                .When(command => command.ValidTo.HasValue)
                .NotNull()
                .WithMessage("ValidTo is required when ValidFrom is provided.")
                .When(x => x.ValidTo.HasValue);
        }

        private bool NotBeNaN(decimal? value)
        {
            return decimal.TryParse(value.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _);
        }

        private bool BeInTheFuture(DateTime? dateTime)
        {
            return dateTime > DateTime.UtcNow;
        }
    }
}
