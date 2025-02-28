using FluentValidation;

using SAX.Application.Features.Orders.DTOs;

namespace SAX.Application.Features.Orders.Validators;

public class PaymentTransactionDtoValidator : AbstractValidator<PaymentTransactionDto>
{
    public PaymentTransactionDtoValidator()
    {
        RuleFor(p => p.OrderId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.TransactionDate)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Amount)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(p => p.PaymentStatus)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.PaymentGatewayReference)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");
    }
}