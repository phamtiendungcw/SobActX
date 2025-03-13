using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.BlogPost.CreateBlogPost;

public sealed class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
{
    public CreateBlogPostCommandValidator()
    {
        RuleFor(x => x.CreateBlogPostDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateBlogPostDtoValidator());
    }
}