using FluentValidation;

using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.Validators;

public class CreateBlogPostDtoValidator : AbstractValidator<CreateBlogPostDto>
{
    public CreateBlogPostDtoValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p => p.Slug)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p => p.ContentBody)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.PublishDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("{PropertyName} must be a date in the past or present.");

        RuleFor(p => p.AuthorId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.TagIds)
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.");
    }
}