using FluentValidation;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Validators;

public sealed class CreateMediaDtoValidator : AbstractValidator<CreateMediaDto>
{
    public CreateMediaDtoValidator()
    {
        RuleFor(p => p.FileName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.FilePath)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(500).WithMessage("{PropertyName} không được vượt quá 500 ký tự.");
        RuleFor(p => p.MediaType)
            .IsInEnum().WithMessage("{PropertyName} phải là một giá trị hợp lệ."); // Validate enum
    }
}