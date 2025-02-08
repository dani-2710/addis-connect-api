using Domain.Constants;
using FluentValidation;

namespace Application.Features.Organizers.UpdateOrganizer
{
    internal sealed class UpdateOrganizerCommandValidator : AbstractValidator<UpdateOrganizerCommand>
    {
        private string[] allowedUserStatus = [UserStatus.Active, UserStatus.Inactive];
        public UpdateOrganizerCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.Email).EmailAddress().When(command => command.Email != null);
            RuleFor(command => command.Status).Must(value => allowedUserStatus.Contains(value))
                .When(command => command.Status != null)
                .WithMessage($"Status must be in [{string.Join(",", allowedUserStatus)}]");
        }
    }
}
