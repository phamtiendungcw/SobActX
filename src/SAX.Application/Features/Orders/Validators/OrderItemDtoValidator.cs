﻿using FluentValidation;

using SAX.Application.Features.Orders.DTOs.OrderItem;

namespace SAX.Application.Features.Orders.Validators;

public sealed class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
{
    public OrderItemDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.Quantity)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .GreaterThan(0).WithMessage("{PropertyName} phải lớn hơn 0.");
        RuleFor(p => p.UnitPrice)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .GreaterThan(0).WithMessage("{PropertyName} phải lớn hơn 0.");
        RuleFor(p => p.LineItemTotal)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");
    }
}