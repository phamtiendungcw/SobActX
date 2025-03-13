using FluentValidation;

using SAX.Application.Features.Users.DTOs;

namespace SAX.Application.Features.Users.Validators;

public sealed class RolePermissionDtoValidator : AbstractValidator<RolePermissionDto>
{
    public RolePermissionDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.RoleId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.PermissionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
    }
}