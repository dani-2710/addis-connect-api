using Domain.Entities;
using FluentValidation;

namespace Application.Features.Organizers.GetFilteredOrganizers
{
    internal sealed class GetFilteredOrganizersQueryValidator : AbstractValidator<GetFilteredOrganizersQuery>
    {
        private int[] allowedPageSizes = [5, 10, 15, 30];
        private string[] allowedSortByColNames =
            [nameof(Organizer.Name), nameof(Organizer.PhoneNumber), nameof(Organizer.Email)];

        public GetFilteredOrganizersQueryValidator()
        {
            RuleFor(query => query.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(query => query.PageSize)
               .Must(value => allowedPageSizes.Contains(value))
               .WithMessage($"Page size must be in [{string.Join(",", allowedPageSizes)}]");

            RuleFor(query => query.SortBy)
                .Must(value => allowedSortByColNames.Any(col => col.ToLower() == value?.ToLower()))
                .When(query => query.SortBy != null)
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColNames)}]");
        }
    }
}
