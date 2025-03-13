using FluentValidation;

using SAX.Application.Features.Orders.Validators;

namespace SAX.Application.Features.Orders.Commands.Order.UpdateOrder;

public sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(p => p.UpdateOrderDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateOrderDtoValidator());
    }
}