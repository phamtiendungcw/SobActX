using FluentValidation;

using SAX.Application.Features.Logging.DTOs;

namespace SAX.Application.Features.Logging.Validators;

public sealed class LogEntryDtoValidator : AbstractValidator<LogEntryDto>
{
    public LogEntryDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.LogLevel)
            .IsInEnum().WithMessage("{PropertyName} phải là một giá trị hợp lệ.");
        RuleFor(p => p.Source)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.Message)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}