using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.CreateStockMovement;

public class CreateStockMovementCommandValidator : AbstractValidator<CreateStockMovementCommand>
{
    public CreateStockMovementCommandValidator()
    {
        RuleFor(p => p.StockMovement)
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .SetValidator(new StockMovementDtoValidator());
    }
}