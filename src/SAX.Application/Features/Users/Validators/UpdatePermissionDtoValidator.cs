using FluentValidation;

using SAX.Application.Features.Users.DTOs.Permission;

namespace SAX.Application.Features.Users.Validators;

public class UpdatePermissionDtoValidator : AbstractValidator<UpdatePermissionDto>
{
    public UpdatePermissionDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.PermissionName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.Description)
            .MaximumLength(1000).WithMessage("{PropertyName} không được vượt quá 1000 ký tự.");
    }
}