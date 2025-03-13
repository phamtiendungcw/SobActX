using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.StockMovement;

namespace SAX.Application.Features.Inventory.Validators;

public sealed class CreateStockMovementDtoValidator : AbstractValidator<CreateStockMovementDto>
{
    public CreateStockMovementDtoValidator()
    {
        RuleFor(p => p.ProductInventoryId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.QuantityChanged)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.MovementType)
            .IsInEnum().WithMessage("{PropertyName} phải là một giá trị hợp lệ."); // Sử dụng IsInEnum()
        RuleFor(p => p.Reason)
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}