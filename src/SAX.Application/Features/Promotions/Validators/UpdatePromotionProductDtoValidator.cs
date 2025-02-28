using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.PromotionProduct;

namespace SAX.Application.Features.Promotions.Validators;

public class UpdatePromotionProductDtoValidator : AbstractValidator<UpdatePromotionProductDto>
{
    public UpdatePromotionProductDtoValidator()
    {
        RuleFor(p => p.PromotionProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.PromotionId.HasValue);

        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.ProductId.HasValue);
    }
}