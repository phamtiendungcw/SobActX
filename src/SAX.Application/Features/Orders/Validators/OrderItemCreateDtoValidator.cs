using FluentValidation;

using SAX.Application.Features.Orders.DTOs.OrderItem;

namespace SAX.Application.Features.Orders.Validators;

public class OrderItemCreateDtoValidator : AbstractValidator<OrderItemCreateDto>
{
    public OrderItemCreateDtoValidator()
    {
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1.");
    }
}