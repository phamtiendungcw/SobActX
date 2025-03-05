using FluentValidation;

using SAX.Application.Features.Content.DTOs.Tag;

namespace SAX.Application.Features.Content.Validators;

public class UpdateTagDtoValidator : AbstractValidator<UpdateTagDto>
{
    public UpdateTagDtoValidator()
    {
        RuleFor(p => p.TagId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.TagName)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            .When(p => !string.IsNullOrEmpty(p.TagName));
    }
}