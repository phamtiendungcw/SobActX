using FluentValidation;

using SAX.Application.Features.Orders.DTOs;

namespace SAX.Application.Features.Orders.Validators;

public sealed class OrderStatusHistoryDtoValidator : AbstractValidator<OrderStatusHistoryDto>
{
    public OrderStatusHistoryDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.OrderId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.Status)
            .IsInEnum().WithMessage("{PropertyName} phải là một giá trị hợp lệ.");
        RuleFor(p => p.Notes)
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}