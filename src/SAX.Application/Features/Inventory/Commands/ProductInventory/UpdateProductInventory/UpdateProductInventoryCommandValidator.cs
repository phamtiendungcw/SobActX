using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.UpdateProductInventory;

public class UpdateProductInventoryCommandValidator : AbstractValidator<UpdateProductInventoryCommand>
{
    public UpdateProductInventoryCommandValidator()
    {
        RuleFor(p => p.UpdateProductInventoryDto).NotNull().WithMessage("{PropertyName} cannot be null.");
        RuleFor(p => p.UpdateProductInventoryDto!).SetValidator(new UpdateProductInventoryDtoValidator());
    }
}