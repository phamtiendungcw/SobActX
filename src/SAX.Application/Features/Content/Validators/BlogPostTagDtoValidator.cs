using FluentValidation;

using SAX.Application.Features.Content.DTOs.BlogPostTag;

namespace SAX.Application.Features.Content.Validators;

public sealed class BlogPostTagDtoValidator : AbstractValidator<BlogPostTagDto>
{
    public BlogPostTagDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.BlogPostId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.TagId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
    }
}