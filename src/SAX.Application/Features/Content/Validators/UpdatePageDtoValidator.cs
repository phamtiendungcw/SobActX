using FluentValidation;

using SAX.Application.Features.Content.DTOs.Page;

namespace SAX.Application.Features.Content.Validators;

public class UpdatePageDtoValidator : AbstractValidator<UpdatePageDto>
{
    public UpdatePageDtoValidator()
    {
        RuleFor(p => p.PageId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Title)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
            .When(p => !string.IsNullOrEmpty(p.Title));

        RuleFor(p => p.Slug)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
            .When(p => !string.IsNullOrEmpty(p.Slug));

        RuleFor(p => p.ContentBody)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => !string.IsNullOrEmpty(p.ContentBody));

        RuleFor(p => p.PublishDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("{PropertyName} must be a date in the past or present.")
            .When(p => p.PublishDate.HasValue);

        RuleFor(p => p.AuthorId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => p.AuthorId.HasValue);
    }
}