using FluentValidation;

using SAX.Application.Features.Customers.DTOs.Customer;

namespace SAX.Application.Features.Customers.Validators;

public class CustomerDtoValidator : AbstractValidator<CustomerDto>
{
    public CustomerDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.")
            .EmailAddress().WithMessage("{PropertyName} không hợp lệ.");
        RuleFor(p => p.PhoneNumber)
            .MaximumLength(20).WithMessage("{PropertyName} không được vượt quá 20 ký tự.")
            .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").WithMessage("{PropertyName} không hợp lệ.");
    }
}