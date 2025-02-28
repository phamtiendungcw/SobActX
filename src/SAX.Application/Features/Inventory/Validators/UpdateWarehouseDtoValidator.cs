using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.Warehouse;

namespace SAX.Application.Features.Inventory.Validators;

public class UpdateWarehouseDtoValidator : AbstractValidator<UpdateWarehouseDto>
{
    public UpdateWarehouseDtoValidator()
    {
        RuleFor(p => p.WarehouseId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.WarehouseName)
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.WarehouseName));

        RuleFor(p => p.StreetAddress)
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.StreetAddress));

        RuleFor(p => p.City)
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.City));

        RuleFor(p => p.State)
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.State));

        RuleFor(p => p.ZipCode)
            .MaximumLength(20).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.ZipCode));

        RuleFor(p => p.Country)
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.Country));
    }
}