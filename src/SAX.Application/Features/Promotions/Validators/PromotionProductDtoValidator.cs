using FluentValidation;

using SAX.Application.Features.Promotions.DTOs;

namespace SAX.Application.Features.Promotions.Validators;

public class PromotionProductDtoValidator : AbstractValidator<PromotionProductDto>
{
    public PromotionProductDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
    }
}