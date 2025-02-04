using FluentValidation;

namespace Application.Features.Authentication.Register
{
    internal sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.LastName).NotEmpty();
            RuleFor(command => command.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.PhoneNumber).NotEmpty();
            RuleFor(command => command.Password).NotEmpty().MinimumLength(8);
        }
    }
}
