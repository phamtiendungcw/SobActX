using FluentValidation;

using SAX.Application.Features.Content.DTOs.BlogPostTag;

namespace SAX.Application.Features.Content.Validators;

public class CreateBlogPostTagDtoValidator : AbstractValidator<CreateBlogPostTagDto>
{
    public CreateBlogPostTagDtoValidator()
    {
        RuleFor(p => p.BlogPostId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.TagId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
    }
}