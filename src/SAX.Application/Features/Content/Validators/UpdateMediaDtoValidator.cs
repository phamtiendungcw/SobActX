using FluentValidation;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Validators;

public class UpdateMediaDtoValidator : AbstractValidator<UpdateMediaDto>
{
    public UpdateMediaDtoValidator()
    {
        RuleFor(p => p.MediaId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.FileName)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.")
            .When(p => !string.IsNullOrEmpty(p.FileName));

        RuleFor(p => p.FilePath)
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.")
            .When(p => !string.IsNullOrEmpty(p.FilePath));

        RuleFor(p => p.MediaType)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            .When(p => !string.IsNullOrEmpty(p.MediaType));
    }
}