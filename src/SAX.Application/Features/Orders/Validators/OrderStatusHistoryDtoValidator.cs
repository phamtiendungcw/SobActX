using FluentValidation;

using SAX.Application.Features.Orders.DTOs;

namespace SAX.Application.Features.Orders.Validators;

public class OrderStatusHistoryDtoValidator : AbstractValidator<OrderStatusHistoryDto>
{
    public OrderStatusHistoryDtoValidator()
    {
        RuleFor(p => p.OrderId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Status)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.StatusDate)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Notes)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
    }
}