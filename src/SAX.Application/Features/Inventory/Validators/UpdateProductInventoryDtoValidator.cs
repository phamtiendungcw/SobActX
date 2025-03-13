using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.Validators;

public sealed class UpdateProductInventoryDtoValidator : AbstractValidator<UpdateProductInventoryDto>
{
    public UpdateProductInventoryDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.WarehouseId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
    }
}