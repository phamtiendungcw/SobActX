using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.UpdateProductInventory;

public sealed class UpdateProductInventoryCommandValidator : AbstractValidator<UpdateProductInventoryCommand>
{
    public UpdateProductInventoryCommandValidator()
    {
        RuleFor(p => p.UpdateProductInventoryDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateProductInventoryDtoValidator());
    }
}