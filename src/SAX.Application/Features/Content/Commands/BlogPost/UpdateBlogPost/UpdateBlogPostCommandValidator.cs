using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.BlogPost.UpdateBlogPost;

public sealed class UpdateBlogPostCommandValidator : AbstractValidator<UpdateBlogPostCommand>
{
    public UpdateBlogPostCommandValidator()
    {
        RuleFor(p => p.UpdateBlogPostDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateBlogPostDtoValidator());
    }
}