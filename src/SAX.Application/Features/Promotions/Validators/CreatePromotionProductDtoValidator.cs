using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.PromotionProduct;

namespace SAX.Application.Features.Promotions.Validators;

public class CreatePromotionProductDtoValidator : AbstractValidator<CreatePromotionProductDto>
{
    public CreatePromotionProductDtoValidator()
    {
        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}