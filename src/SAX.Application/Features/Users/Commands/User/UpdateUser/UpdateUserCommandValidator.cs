using FluentValidation;

using SAX.Application.Features.Users.Validators;

namespace SAX.Application.Features.Users.Commands.User.UpdateUser;

public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UpdateUserDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateUserDtoValidator());
    }
}