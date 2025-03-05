using FluentValidation;

using SAX.Application.Features.Users.DTOs.UserRole;

namespace SAX.Application.Features.Users.Validators;

public class UpdateUserRoleDtoValidator : AbstractValidator<UpdateUserRoleDto>
{
    public UpdateUserRoleDtoValidator()
    {
        RuleFor(p => p.UserRoleId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.RoleId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => p.RoleId.HasValue);

        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => p.UserId.HasValue);
    }
}