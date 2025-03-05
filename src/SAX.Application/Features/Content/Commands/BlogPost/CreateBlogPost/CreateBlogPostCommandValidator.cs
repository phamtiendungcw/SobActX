using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.BlogPost.CreateBlogPost;

public class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
{
    public CreateBlogPostCommandValidator()
    {
        RuleFor(x => x.CreateBlogPostDto).NotNull().WithMessage("CreateBlogPostDto cannot be null.");
        RuleFor(x => x.CreateBlogPostDto).SetValidator(new CreateBlogPostDtoValidator());
    }
}