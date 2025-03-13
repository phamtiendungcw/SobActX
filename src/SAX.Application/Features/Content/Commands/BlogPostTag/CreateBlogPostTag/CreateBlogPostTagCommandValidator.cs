using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.BlogPostTag.CreateBlogPostTag;

public sealed class CreateBlogPostTagCommandValidator : AbstractValidator<CreateBlogPostTagCommand>
{
    public CreateBlogPostTagCommandValidator()
    {
        RuleFor(x => x.CreateBlogPostTagDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateBlogPostTagDtoValidator());
    }
}