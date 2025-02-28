using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.Validators;

public class CreatePromotionDtoValidator : AbstractValidator<CreatePromotionDto>
{
    public CreatePromotionDtoValidator()
    {
        RuleFor(p => p.PromotionName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.PromotionType)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.DiscountValue)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");

        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .LessThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} phải nhỏ hơn hoặc bằng {ComparisonValue}.");

        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} phải lớn hơn hoặc bằng {ComparisonValue}.");

        RuleFor(p => p.CouponCode)
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.MinimumOrderValue)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");
    }
}