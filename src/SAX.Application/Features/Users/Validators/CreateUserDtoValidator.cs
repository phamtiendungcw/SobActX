using FluentValidation;

using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Users.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(8).WithMessage("{PropertyName} must be at least {MinLength} characters."); // Yêu cầu mật khẩu mạnh hơn
        RuleFor(p => p.Password)
            .Matches(@"[A-Z]+").WithMessage("{PropertyName} must contain at least one capital letter.") // Yêu cầu mật khẩu mạnh hơn
            .Matches(@"[a-z]+").WithMessage("{PropertyName} must contain at least one normal letter.")
            .Matches(@"[0-9]+").WithMessage("{PropertyName} must contain at least some.")
            .Matches(@"[\W_]+").WithMessage("{PropertyName} must contain at least one special characters.");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .EmailAddress().WithMessage("{PropertyName} not in accordance with email format.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
    }
}