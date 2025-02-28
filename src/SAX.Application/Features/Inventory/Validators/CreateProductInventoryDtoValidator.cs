using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.Validators;

public class CreateProductInventoryDtoValidator : AbstractValidator<CreateProductInventoryDto>
{
    public CreateProductInventoryDtoValidator()
    {
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.WarehouseId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.QuantityOnHand)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");

        RuleFor(p => p.QuantityAvailable)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");
    }
}