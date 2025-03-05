using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.BlogPost.UpdateBlogPost;

public class UpdateBlogPostCommandValidator : AbstractValidator<UpdateBlogPostCommand>
{
    public UpdateBlogPostCommandValidator()
    {
        RuleFor(p => p.UpdateBlogPostDto).NotNull().WithMessage("UpdateBlogPostDto cannot be null.");
        RuleFor(x => x.UpdateBlogPostDto).SetValidator(new UpdateBlogPostDtoValidator());
    }
}