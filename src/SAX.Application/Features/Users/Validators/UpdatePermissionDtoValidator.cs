using FluentValidation;

using SAX.Application.Features.Users.DTOs.Permission;

namespace SAX.Application.Features.Users.Validators;

public class UpdatePermissionDtoValidator : AbstractValidator<UpdatePermissionDto>
{
    public UpdatePermissionDtoValidator()
    {
        RuleFor(p => p.PermissionId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.PermissionName)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.PermissionName));

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.Description));
    }
}