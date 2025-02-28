using FluentValidation;

using SAX.Application.Features.Products.DTOs.ProductReview;

namespace SAX.Application.Features.Products.Validators;

public class CreateProductReviewDtoValidator : AbstractValidator<CreateProductReviewDto>
{
    public CreateProductReviewDtoValidator()
    {
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Rating)
            .InclusiveBetween(1, 5).WithMessage("{PropertyName} must be between 1 and 5.");

        RuleFor(p => p.Comment)
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
    }
}