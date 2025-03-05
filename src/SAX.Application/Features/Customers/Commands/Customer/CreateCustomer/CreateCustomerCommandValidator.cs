using FluentValidation;

using SAX.Application.Features.Customers.Validators;

namespace SAX.Application.Features.Customers.Commands.Customer.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.CreateCustomerDto).NotNull().WithMessage("CreateCustomerDto is required");
        RuleFor(x => x.CreateCustomerDto!).SetValidator(new CreateCustomerDtoValidator());
    }
}