using FluentValidation;

using SAX.Application.Features.Users.DTOs.Role;

namespace SAX.Application.Features.Users.Validators;

public class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
{
    public CreateRoleDtoValidator()
    {
        RuleFor(p => p.RoleName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
    }
}