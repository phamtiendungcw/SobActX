using FluentValidation;

using SAX.Application.Features.Orders.DTOs;

namespace SAX.Application.Features.Orders.Validators;

public class ShoppingCartItemDtoValidator : AbstractValidator<ShoppingCartItemDto>
{
    public ShoppingCartItemDtoValidator()
    {
        RuleFor(p => p.ShoppingCartId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Product)
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .DependentRules(() => // Sử dụng các quy tắc phụ thuộc cho các quy tắc chuỗi trên property của sản phẩm
            {
                RuleFor(p => p.Product!.ProductId)
                    .NotEmpty().WithMessage("Product.ProductId is required.");
            });

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");
    }
}