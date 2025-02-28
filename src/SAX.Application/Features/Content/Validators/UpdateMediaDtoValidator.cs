using FluentValidation;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Validators;

public class UpdateMediaDtoValidator : AbstractValidator<UpdateMediaDto>
{
    public UpdateMediaDtoValidator()
    {
        RuleFor(p => p.MediaId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.FileName)
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.FileName));

        RuleFor(p => p.FilePath)
            .MaximumLength(1000).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.FilePath));

        RuleFor(p => p.MediaType)
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.MediaType));
    }
}