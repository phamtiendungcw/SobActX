using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.CreateStockMovement;

public class CreateStockMovementCommandValidator : AbstractValidator<CreateStockMovementCommand>
{
    public CreateStockMovementCommandValidator()
    {
        RuleFor(p => p.StockMovementDto).NotNull().WithMessage("{PropertyName} cannot be null.");
        RuleFor(p => p.StockMovementDto!).SetValidator(new StockMovementDtoValidator());
    }
}