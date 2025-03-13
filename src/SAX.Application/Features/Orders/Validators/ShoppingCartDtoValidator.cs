using FluentValidation;

using SAX.Application.Features.Orders.DTOs;

namespace SAX.Application.Features.Orders.Validators;

public sealed class ShoppingCartDtoValidator : AbstractValidator<ShoppingCartDto>
{
    public ShoppingCartDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
    }
}