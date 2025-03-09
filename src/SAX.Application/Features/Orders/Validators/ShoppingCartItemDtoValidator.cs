using FluentValidation;

using SAX.Application.Features.Orders.DTOs;

namespace SAX.Application.Features.Orders.Validators;

public class ShoppingCartItemDtoValidator : AbstractValidator<ShoppingCartItemDto>
{
    public ShoppingCartItemDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ShoppingCartId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .GreaterThan(0).WithMessage("{PropertyName} phải lớn hơn 0.");
    }
}