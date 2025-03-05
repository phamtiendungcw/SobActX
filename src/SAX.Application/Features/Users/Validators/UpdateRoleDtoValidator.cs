using FluentValidation;

using SAX.Application.Features.Users.DTOs.Role;

namespace SAX.Application.Features.Users.Validators;

public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
{
    public UpdateRoleDtoValidator()
    {
        RuleFor(p => p.RoleId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.RoleName)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.RoleName));

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.Description));
    }
}