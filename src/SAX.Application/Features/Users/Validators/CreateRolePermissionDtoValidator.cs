using FluentValidation;

using SAX.Application.Features.Users.DTOs.RolePermission;

namespace SAX.Application.Features.Users.Validators;

public class CreateRolePermissionDtoValidator : AbstractValidator<CreateRolePermissionDto>
{
    public CreateRolePermissionDtoValidator()
    {
        RuleFor(p => p.RoleId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.PermissionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");
    }
}