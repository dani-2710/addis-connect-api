using Domain.Constants;
using FluentValidation;

namespace Application.Features.Categories.UpdateCategory
{
    internal sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        string[] allowedCategoryStatus = [CategoryStatus.Active, CategoryStatus.Inactive];

        public UpdateCategoryCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();

            RuleFor(command => command.Status).Must(value => allowedCategoryStatus.Contains(value))
                .When(command => command.Status != null)
                .WithMessage($"Status must be in [{string.Join(",", allowedCategoryStatus)}]");
        }
    }
}
