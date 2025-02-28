using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.PromotionCategory;

namespace SAX.Application.Features.Promotions.Validators;

public class CreatePromotionCategoryDtoValidator : AbstractValidator<CreatePromotionCategoryDto>
{
    public CreatePromotionCategoryDtoValidator()
    {
        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.ProductCategoryId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");
    }
}