using FluentValidation;

using SAX.Application.Features.Logging.DTOs;

namespace SAX.Application.Features.Logging.Validators;

public class LogEntryDtoValidator : AbstractValidator<LogEntryDto>
{
    public LogEntryDtoValidator()
    {
        RuleFor(p => p.Timestamp)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.LogLevel)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

        RuleFor(p => p.Source)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.Message)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Exception)
            .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters.");
    }
}