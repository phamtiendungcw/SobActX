using FluentValidation;

using SAX.Application.Features.Orders.Validators;

namespace SAX.Application.Features.Orders.Commands.Order.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CreateOrderDto).NotNull().WithMessage("CreateOrderDto is required.");
        RuleFor(x => x.CreateOrderDto!).SetValidator(new CreateOrderDtoValidator());
    }
}