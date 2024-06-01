using FluentValidation;

namespace UserModule.Core.Commands.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(U => U.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(U => U.PhoneNumber)
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(11);
        }
    }
}
