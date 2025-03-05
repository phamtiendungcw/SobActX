using FluentValidation;

using SAX.Application.Features.Products.Validators;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;

public class CreateProductInventoryCommandValidator : AbstractValidator<CreateProductInventoryCommand>
{
    public CreateProductInventoryCommandValidator()
    {
        RuleFor(x => x.CreateProductDto).NotNull().WithMessage("CreateProductDto is required");
        RuleFor(x => x.CreateProductDto).SetValidator(new CreateProductDtoValidator());
    }
}