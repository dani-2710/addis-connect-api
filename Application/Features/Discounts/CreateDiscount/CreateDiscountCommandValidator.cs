using Domain.Constants;
using FluentValidation;
using System.Globalization;

namespace Application.Features.Discounts.CreateDiscount
{
    internal sealed class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
    {
        string[] allowedDiscountAmountTypes = [DiscountAmountTypes.Percentage, DiscountAmountTypes.Fixed];

        public CreateDiscountCommandValidator()
        {
            RuleFor(command => command.AmountType).NotEmpty()
                .Must(value => allowedDiscountAmountTypes.Contains(value))
                .WithMessage($"AmountType must be in [{string.Join(",", allowedDiscountAmountTypes)}]");

            RuleFor(command => command.Amount).NotEmpty()
                .Must(NotBeNaN)
                .WithMessage("Invalid Amount")
                .LessThanOrEqualTo(100)
                .When(command => command.AmountType == DiscountAmountTypes.Percentage)
                .WithMessage("Amount must be in [0,100]")
                .GreaterThan(0);

            RuleFor(command => command.ValidFrom).NotEmpty()
                .Must(BeInTheFuture)
                .WithMessage("ValidFrom must be in the future")
                .LessThan(command => command.ValidTo)
                .WithMessage("ValidFrom must be less than ValidTo");

            RuleFor(command => command.ValidTo).NotEmpty()
                .Must(BeInTheFuture)
                .WithMessage("ValidFrom must be in the future");
        }

        private bool NotBeNaN(decimal value)
        {
            return decimal.TryParse(value.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _);
        }

        private bool BeInTheFuture(DateTime dateTime)
        {
            return dateTime > DateTime.UtcNow;
        }
    }
}
