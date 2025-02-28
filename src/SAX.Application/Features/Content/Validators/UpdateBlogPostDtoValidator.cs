using FluentValidation;

using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.Validators;

public class UpdateBlogPostDtoValidator : AbstractValidator<UpdateBlogPostDto>
{
    public UpdateBlogPostDtoValidator()
    {
        RuleFor(p => p.BlogPostId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.Title)
            .MaximumLength(200).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.Title));

        RuleFor(p => p.Slug)
            .MaximumLength(200).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.Slug));

        RuleFor(p => p.ContentBody)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => !string.IsNullOrEmpty(p.ContentBody));

        RuleFor(p => p.PublishDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} phải là ngày trong quá khứ hoặc hiện tại.")
            .When(p => p.PublishDate.HasValue);

        RuleFor(p => p.AuthorId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.AuthorId.HasValue);

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.CategoryId.HasValue);

        RuleFor(p => p.TagIds)
            .NotNull().WithMessage("{PropertyName} không được null.")
            .When(p => p.TagIds != null);
    }
}