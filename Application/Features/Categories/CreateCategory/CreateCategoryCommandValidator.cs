using FluentValidation;

namespace Application.Features.Categories.CreateCategory
{
    internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.Icon).NotEmpty();
        }
    }
}
