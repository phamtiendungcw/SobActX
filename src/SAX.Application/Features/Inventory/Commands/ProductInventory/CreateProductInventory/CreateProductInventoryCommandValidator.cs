using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;

public class CreateProductInventoryCommandValidator : AbstractValidator<CreateProductInventoryCommand>
{
    public CreateProductInventoryCommandValidator()
    {
        RuleFor(x => x.CreateProductInventoryDto).NotNull().WithMessage("CreateProductInventoryDto is required");
        RuleFor(x => x.CreateProductInventoryDto!).SetValidator(new CreateProductInventoryDtoValidator());
    }
}