using FluentValidation;

using SAX.Application.Features.Customers.DTOs;

namespace SAX.Application.Features.Customers.Validators;

public class AddressDtoValidator : AbstractValidator<AddressDto>
{
    public AddressDtoValidator()
    {
        RuleFor(p => p.StreetAddress)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.City)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.State)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.ZipCode)
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

        RuleFor(p => p.Country)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
    }
}