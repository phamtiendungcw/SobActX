using FluentValidation;

using SAX.Application.Features.Orders.DTOs.Order;

namespace SAX.Application.Features.Orders.Validators;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.OrderItems)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Must(orderItems => orderItems != null && orderItems.Any()).WithMessage("{PropertyName} must contain at least one product.");

        RuleForEach(p => p.OrderItems).SetValidator(new OrderItemCreateDtoValidator());

        RuleFor(p => p.ShippingAddressStreet)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        RuleFor(p => p.ShippingAddressCity)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        RuleFor(p => p.ShippingAddressCountry)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.BillingAddressStreet)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        RuleFor(p => p.BillingAddressCity)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        RuleFor(p => p.BillingAddressCountry)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.PaymentMethod)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
    }
}