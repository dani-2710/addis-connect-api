using FluentValidation;

namespace Application.Features.Categories.GetCategoryById
{
    internal sealed class GetCategoryByIdQueryValidatory : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidatory()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
