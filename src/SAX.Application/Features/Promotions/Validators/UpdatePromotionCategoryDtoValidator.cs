using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.PromotionCategory;

namespace SAX.Application.Features.Promotions.Validators;

public class UpdatePromotionCategoryDtoValidator : AbstractValidator<UpdatePromotionCategoryDto>
{
    public UpdatePromotionCategoryDtoValidator()
    {
        RuleFor(p => p.PromotionCategoryId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.PromotionId.HasValue);

        RuleFor(p => p.ProductCategoryId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.ProductCategoryId.HasValue);
    }
}