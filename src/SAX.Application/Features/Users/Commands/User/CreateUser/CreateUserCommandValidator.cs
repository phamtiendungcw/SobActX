using FluentValidation;

using SAX.Application.Features.Users.Validators;

namespace SAX.Application.Features.Users.Commands.User.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.CreateUserDto).NotNull().WithMessage("CreateUserDto is required.");
        RuleFor(x => x.CreateUserDto!).SetValidator(new CreateUserDtoValidator());
    }
}