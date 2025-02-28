using FluentValidation;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Validators;

public class CreateMediaDtoValidator : AbstractValidator<CreateMediaDto>
{
    public CreateMediaDtoValidator()
    {
        RuleFor(p => p.FileName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.FilePath)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(1000).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.MediaType)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");
    }
}