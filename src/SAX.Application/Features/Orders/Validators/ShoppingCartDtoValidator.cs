using FluentValidation;

using SAX.Application.Features.Orders.DTOs;

namespace SAX.Application.Features.Orders.Validators;

public class ShoppingCartDtoValidator : AbstractValidator<ShoppingCartDto>
{
    public ShoppingCartDtoValidator()
    {
        RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}