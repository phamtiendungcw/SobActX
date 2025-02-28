using FluentValidation;

using SAX.Application.Features.Users.DTOs.RolePermission;

namespace SAX.Application.Features.Users.Validators;

public class UpdateRolePermissionDtoValidator : AbstractValidator<UpdateRolePermissionDto>
{
    public UpdateRolePermissionDtoValidator()
    {
        RuleFor(p => p.RolePermissionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.RoleId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.RoleId.HasValue);

        RuleFor(p => p.PermissionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.PermissionId.HasValue);
    }
}