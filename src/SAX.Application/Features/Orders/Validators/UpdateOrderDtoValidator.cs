using FluentValidation;

using SAX.Application.Features.Orders.DTOs.Order;

namespace SAX.Application.Features.Orders.Validators;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(p => p.OrderId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.OrderStatus)
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.OrderStatus));

        RuleFor(p => p.DiscountAmount)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.")
            .When(p => p.DiscountAmount.HasValue);

        RuleFor(p => p.ShippingCost)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.")
            .When(p => p.ShippingCost.HasValue);
    }
}