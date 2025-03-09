using FluentValidation;

using SAX.Application.Features.Orders.DTOs;

namespace SAX.Application.Features.Orders.Validators;

public class PaymentTransactionDtoValidator : AbstractValidator<PaymentTransactionDto>
{
    public PaymentTransactionDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.OrderId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.Amount)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .GreaterThan(0).WithMessage("{PropertyName} phải lớn hơn 0.");
        RuleFor(p => p.PaymentStatus)
            .IsInEnum().WithMessage("{PropertyName} phải là một giá trị hợp lệ.");
        RuleFor(p => p.PaymentGatewayReference)
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}