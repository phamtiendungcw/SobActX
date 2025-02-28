using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.PromotionProduct;

namespace SAX.Application.Features.Promotions.Validators;

public class CreatePromotionProductDtoValidator : AbstractValidator<CreatePromotionProductDto>
{
    public CreatePromotionProductDtoValidator()
    {
        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");
    }
}