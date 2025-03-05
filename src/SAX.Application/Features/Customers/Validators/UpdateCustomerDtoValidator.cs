using FluentValidation;

using SAX.Application.Features.Customers.DTOs.Customer;

namespace SAX.Application.Features.Customers.Validators;

public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
{
    public UpdateCustomerDtoValidator()
    {
        RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.FirstName)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            .When(p => !string.IsNullOrEmpty(p.FirstName));

        RuleFor(p => p.LastName)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            .When(p => !string.IsNullOrEmpty(p.LastName));

        RuleFor(p => p.PhoneNumber)
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
            .When(p => !string.IsNullOrEmpty(p.PhoneNumber));

        RuleFor(p => p.StreetAddress)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.")
            .When(p => !string.IsNullOrEmpty(p.StreetAddress));

        RuleFor(p => p.City)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.City));

        RuleFor(p => p.State)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.State));

        RuleFor(p => p.ZipCode)
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
            .When(p => !string.IsNullOrEmpty(p.ZipCode));

        RuleFor(p => p.Country)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.Country));
    }
}