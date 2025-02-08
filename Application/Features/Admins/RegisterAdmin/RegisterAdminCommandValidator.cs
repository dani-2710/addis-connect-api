using FluentValidation;

namespace Application.Features.Admins.RegisterAdmin
{
    internal sealed class RegisterAdminCommandValidator : AbstractValidator<RegisterAdminCommand>
    {
        public RegisterAdminCommandValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.LastName).NotEmpty();
            RuleFor(command => command.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.PhoneNumber).NotEmpty();
            RuleFor(command => command.Password).NotEmpty();
        }
    }
}
