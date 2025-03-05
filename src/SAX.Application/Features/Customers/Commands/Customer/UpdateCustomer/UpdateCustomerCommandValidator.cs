using FluentValidation;

using SAX.Application.Features.Customers.Validators;

namespace SAX.Application.Features.Customers.Commands.Customer.UpdateCustomer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.UpdateCustomerDto).NotNull().WithMessage("UpdateCustomerDto is required");
        RuleFor(x => x.UpdateCustomerDto).SetValidator(new UpdateCustomerDtoValidator());
    }
}