using FluentValidation;

using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Users.Validators;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Username)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.Username));

        RuleFor(p => p.Email)
            .EmailAddress().WithMessage("{PropertyName} not in accordance with email format.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.Email));

        RuleFor(p => p.FirstName)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.FirstName));

        RuleFor(p => p.LastName)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.LastName));
    }
}