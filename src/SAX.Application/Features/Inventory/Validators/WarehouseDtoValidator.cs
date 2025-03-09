using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.Warehouse;

namespace SAX.Application.Features.Inventory.Validators;

public class WarehouseDtoValidator : AbstractValidator<WarehouseDto>
{
    public WarehouseDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.WarehouseName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}