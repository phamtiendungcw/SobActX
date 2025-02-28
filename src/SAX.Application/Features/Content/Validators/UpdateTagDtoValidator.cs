using FluentValidation;

using SAX.Application.Features.Content.DTOs.Tag;

namespace SAX.Application.Features.Content.Validators;

public class UpdateTagDtoValidator : AbstractValidator<UpdateTagDto>
{
    public UpdateTagDtoValidator()
    {
        RuleFor(p => p.TagId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.TagName)
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.TagName));
    }
}