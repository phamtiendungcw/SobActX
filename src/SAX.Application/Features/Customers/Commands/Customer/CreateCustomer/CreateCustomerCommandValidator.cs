using FluentValidation;

using SAX.Application.Features.Customers.Validators;

namespace SAX.Application.Features.Customers.Commands.Customer.CreateCustomer;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.CreateCustomerDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateCustomerDtoValidator());
    }
}