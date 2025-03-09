using FluentValidation;

using SAX.Application.Features.Orders.Validators;

namespace SAX.Application.Features.Orders.Commands.Order.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(p => p.UpdateOrderDto).NotNull().WithMessage("UpdateOrderDto is required.");
        RuleFor(p => p.UpdateOrderDto!).SetValidator(new UpdateOrderDtoValidator());
    }
}