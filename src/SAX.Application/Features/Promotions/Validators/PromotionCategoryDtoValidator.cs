using FluentValidation;

using SAX.Application.Features.Promotions.DTOs;

namespace SAX.Application.Features.Promotions.Validators;

public class PromotionCategoryDtoValidator : AbstractValidator<PromotionCategoryDto>
{
    public PromotionCategoryDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductCategoryId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
    }
}