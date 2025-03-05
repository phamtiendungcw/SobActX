using FluentValidation;

using SAX.Application.Features.Users.DTOs.Permission;

namespace SAX.Application.Features.Users.Validators;

public class CreatePermissionDtoValidator : AbstractValidator<CreatePermissionDto>
{
    public CreatePermissionDtoValidator()
    {
        RuleFor(p => p.PermissionName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
    }
}