using FluentValidation;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Validators;

public class CreateMediaDtoValidator : AbstractValidator<CreateMediaDto>
{
    public CreateMediaDtoValidator()
    {
        RuleFor(p => p.FileName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.FilePath)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

        RuleFor(p => p.MediaType)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}