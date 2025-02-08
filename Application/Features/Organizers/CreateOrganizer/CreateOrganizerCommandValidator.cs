using Application.Features.Authentication.Register;
using Application.Features.Organizers.CreateOrganizer;
using FluentValidation;

namespace Application.Features.Organziers.CreateOrganizer
{
    internal sealed class CreateOrganizerCommandValidator : AbstractValidator<CreateOrganizerCommand>
    {
        public CreateOrganizerCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.PhoneNumber).NotEmpty();
            RuleFor(command => command.UserId).NotEmpty();
        }
    }
}
