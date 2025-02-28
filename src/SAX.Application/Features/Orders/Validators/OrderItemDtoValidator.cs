using FluentValidation;

using SAX.Application.Features.Orders.DTOs.OrderItem;

namespace SAX.Application.Features.Orders.Validators;

public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
{
    public OrderItemDtoValidator()
    {
        RuleFor(p => p.Product)
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .DependentRules(() =>
            {
                RuleFor(p => p.Product!.ProductId)
                    .NotEmpty().WithMessage("Product.ProductId is required.");
            });

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");

        RuleFor(p => p.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");
    }
}