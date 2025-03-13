using FluentValidation;

using SAX.Application.Features.Orders.DTOs.OrderItem;

namespace SAX.Application.Features.Orders.Validators;

public sealed class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemDtoValidator()
    {
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .GreaterThan(0).WithMessage("{PropertyName} phải lớn hơn 0.");
        RuleFor(p => p.UnitPrice)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .GreaterThan(0).WithMessage("{PropertyName} phải lớn hơn 0.");
    }
}