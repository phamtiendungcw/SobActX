using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.StockMovement;

namespace SAX.Application.Features.Inventory.Validators;

public class StockMovementDtoValidator : AbstractValidator<StockMovementDto>
{
    public StockMovementDtoValidator()
    {
        RuleFor(p => p.ProductInventory)
            .NotNull().WithMessage("{PropertyName} cannot be null.");

        RuleFor(p => p.QuantityChanged)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotEqual(0).WithMessage("{PropertyName} must not be zero.");

        RuleFor(p => p.MovementType)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.MovementDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("{PropertyName} must be a date in the past or present.");

        RuleFor(p => p.Reason)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
    }
}