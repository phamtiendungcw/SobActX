using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.PromotionCategory;

namespace SAX.Application.Features.Promotions.Validators;

public class UpdatePromotionCategoryDtoValidator : AbstractValidator<UpdatePromotionCategoryDto>
{
    public UpdatePromotionCategoryDtoValidator()
    {
        RuleFor(p => p.PromotionCategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => p.PromotionId.HasValue);

        RuleFor(p => p.ProductCategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => p.ProductCategoryId.HasValue);
    }
}