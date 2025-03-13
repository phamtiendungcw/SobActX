using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.BlogPostTag.UpdateBlogPostTag;

public sealed class UpdateBlogPostTagCommandValidator : AbstractValidator<UpdateBlogPostTagCommand>
{
    public UpdateBlogPostTagCommandValidator()
    {
        RuleFor(x => x.UpdateBlogPostTagDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateBlogPostTagDtoValidator());
    }
}