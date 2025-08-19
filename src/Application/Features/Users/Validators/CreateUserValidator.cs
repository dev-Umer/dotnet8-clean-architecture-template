using FluentValidation;

namespace Application.Features.Users.Validators;

public sealed class CreateUserValidator : AbstractValidator<Features.Users.Commands.CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty().EmailAddress().MaximumLength(200);
    }
}
