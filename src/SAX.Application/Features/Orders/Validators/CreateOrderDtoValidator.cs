using FluentValidation;

using SAX.Application.Features.Orders.DTOs.Order;

namespace SAX.Application.Features.Orders.Validators;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.OrderItems)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .Must(orderItems => orderItems != null && orderItems.Any()).WithMessage("{PropertyName} phải chứa ít nhất một sản phẩm.");

        RuleForEach(p => p.OrderItems).SetValidator(new OrderItemCreateDtoValidator());

        RuleFor(p => p.ShippingAddressStreet)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
        RuleFor(p => p.ShippingAddressCity)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
        RuleFor(p => p.ShippingAddressCountry)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.BillingAddressStreet)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
        RuleFor(p => p.BillingAddressCity)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
        RuleFor(p => p.BillingAddressCountry)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.PaymentMethod)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
    }
}