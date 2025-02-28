using FluentValidation;

using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Users.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MinimumLength(8).WithMessage("{PropertyName} phải có ít nhất {MinLength} ký tự.");
        RuleFor(p => p.Password)
            .Matches(@"[A-Z]+").WithMessage("{PropertyName} phải chứa ít nhất một chữ cái viết hoa.") // Ví dụ: Yêu cầu mật khẩu mạnh hơn
            .Matches(@"[a-z]+").WithMessage("{PropertyName} phải chứa ít nhất một chữ cái viết thường.")
            .Matches(@"[0-9]+").WithMessage("{PropertyName} phải chứa ít nhất một số.")
            .Matches(@"[\W_]+").WithMessage("{PropertyName} phải chứa ít nhất một ký tự đặc biệt.");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .EmailAddress().WithMessage("{PropertyName} không đúng định dạng email.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
    }
}