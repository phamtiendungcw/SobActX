using FluentValidation;

using SAX.Application.Features.Customers.Validators;

namespace SAX.Application.Features.Customers.Commands.Customer.UpdateCustomer;

public sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.UpdateCustomerDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateCustomerDtoValidator());
    }
}
