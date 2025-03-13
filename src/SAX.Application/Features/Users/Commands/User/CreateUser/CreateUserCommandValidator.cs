using FluentValidation;

using SAX.Application.Features.Users.Validators;

namespace SAX.Application.Features.Users.Commands.User.CreateUser;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.CreateUserDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateUserDtoValidator());
    }
}