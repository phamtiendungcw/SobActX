using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.StockMovement;

namespace SAX.Application.Features.Inventory.Validators;

public class StockMovementDtoValidator : AbstractValidator<StockMovementDto>
{
    public StockMovementDtoValidator()
    {
        RuleFor(p => p.ProductInventory)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.QuantityChanged)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotEqual(0).WithMessage("{PropertyName} phải khác 0.");

        RuleFor(p => p.MovementType)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Reason)
            .MaximumLength(500).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
    }
}