using FluentValidation;

using SAX.Application.Features.Users.DTOs.UserRole;

namespace SAX.Application.Features.Users.Validators;

public class CreateUserRoleDtoValidator : AbstractValidator<CreateUserRoleDto>
{
    public CreateUserRoleDtoValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.RoleId)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}