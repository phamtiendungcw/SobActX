using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.StockMovement;

namespace SAX.Application.Features.Inventory.Validators;

public class StockMovementDtoValidator : AbstractValidator<StockMovementDto>
{
    public StockMovementDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductInventoryId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.QuantityChanged)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.MovementType)
            .IsInEnum().WithMessage("{PropertyName} phải là một giá trị hợp lệ.");
        RuleFor(p => p.Reason)
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}