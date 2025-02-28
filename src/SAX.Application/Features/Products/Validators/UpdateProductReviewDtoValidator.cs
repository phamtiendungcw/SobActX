using FluentValidation;

using SAX.Application.Features.Products.DTOs.ProductReview;

namespace SAX.Application.Features.Products.Validators;

public class UpdateProductReviewDtoValidator : AbstractValidator<UpdateProductReviewDto>
{
    public UpdateProductReviewDtoValidator()
    {
        RuleFor(p => p.ProductReviewId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.Rating)
            .InclusiveBetween(1, 5).WithMessage("{PropertyName} must be between 1 and 5.")
            .When(p => p.Rating != 0); // Validate Rating nếu giá trị khác 0 (mặc định)

        RuleFor(p => p.Comment)
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.")
            .When(p => !string.IsNullOrEmpty(p.Comment));
    }
}