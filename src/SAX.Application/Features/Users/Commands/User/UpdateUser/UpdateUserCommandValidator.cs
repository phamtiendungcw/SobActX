using FluentValidation;

using SAX.Application.Features.Users.Validators;

namespace SAX.Application.Features.Users.Commands.User.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UpdateUserDto).NotNull().WithMessage("UpdateUserDto is required.");
        RuleFor(x => x.UpdateUserDto!).SetValidator(new UpdateUserDtoValidator());

    }
}