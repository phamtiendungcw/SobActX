using FluentValidation;

using SAX.Application.Features.Content.DTOs.Tag;

namespace SAX.Application.Features.Content.Validators;

public sealed class TagDtoValidator : AbstractValidator<TagDto>
{
    public TagDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.TagName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}