using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.CreateStockMovement;

public sealed class CreateStockMovementCommandValidator : AbstractValidator<CreateStockMovementCommand>
{
    public CreateStockMovementCommandValidator()
    {
        RuleFor(p => p.CreateStockMovementDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateStockMovementDtoValidator());
    }
}