using FluentValidation;

using SAX.Application.Features.Orders.DTOs.Order;

namespace SAX.Application.Features.Orders.Validators;

public class OrderDtoValidator : AbstractValidator<OrderDto>
{
    public OrderDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.OrderStatus)
            .IsInEnum().WithMessage("{PropertyName} phải là một giá trị hợp lệ.");
        RuleFor(p => p.PaymentMethod)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.TotalAmount)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");
        RuleFor(p => p.DiscountAmount)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");
        RuleFor(p => p.ShippingCost)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");
    }
}