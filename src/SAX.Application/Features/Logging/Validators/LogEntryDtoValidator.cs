using FluentValidation;

using SAX.Application.Features.Logging.DTOs;

namespace SAX.Application.Features.Logging.Validators;

public class LogEntryDtoValidator : AbstractValidator<LogEntryDto>
{
    public LogEntryDtoValidator()
    {
        RuleFor(p => p.Timestamp)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.LogLevel)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(20).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Source)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Message)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.Exception)
            .MaximumLength(2000).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
    }
}