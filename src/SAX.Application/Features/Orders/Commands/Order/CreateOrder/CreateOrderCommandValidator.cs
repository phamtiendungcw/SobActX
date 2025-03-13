using FluentValidation;

using SAX.Application.Features.Orders.Validators;

namespace SAX.Application.Features.Orders.Commands.Order.CreateOrder;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CreateOrderDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateOrderDtoValidator());
    }
}