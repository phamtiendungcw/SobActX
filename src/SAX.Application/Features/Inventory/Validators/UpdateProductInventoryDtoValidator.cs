using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.Validators;

public class UpdateProductInventoryDtoValidator : AbstractValidator<UpdateProductInventoryDto>
{
    public UpdateProductInventoryDtoValidator()
    {
        RuleFor(p => p.ProductInventoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.QuantityOnHand)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.")
            .When(p => p.QuantityOnHand.HasValue);

        RuleFor(p => p.QuantityAvailable)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.")
            .When(p => p.QuantityAvailable.HasValue);
    }
}