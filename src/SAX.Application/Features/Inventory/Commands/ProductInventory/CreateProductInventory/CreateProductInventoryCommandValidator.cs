using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;

public sealed class CreateProductInventoryCommandValidator : AbstractValidator<CreateProductInventoryCommand>
{
    public CreateProductInventoryCommandValidator()
    {
        RuleFor(x => x.CreateProductInventoryDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateProductInventoryDtoValidator());
    }
}