using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.Validators;

public class UpdatePromotionDtoValidator : AbstractValidator<UpdatePromotionDto>
{
    public UpdatePromotionDtoValidator()
    {
        RuleFor(p => p.PromotionId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.PromotionName)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.PromotionName));

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.Description));

        RuleFor(p => p.PromotionType)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.PromotionType));

        RuleFor(p => p.DiscountValue)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.")
            .When(p => p.DiscountValue != 0); // Validate DiscountValue nếu giá trị khác 0 (mặc định)

        RuleFor(p => p.StartDate)
            .LessThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}.")
            .When(p => p.StartDate.HasValue && p.EndDate.HasValue);

        RuleFor(p => p.EndDate)
            .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.")
            .When(p => p.StartDate.HasValue && p.EndDate.HasValue);

        RuleFor(p => p.CouponCode)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.")
            .When(p => !string.IsNullOrEmpty(p.CouponCode));

        RuleFor(p => p.MinimumOrderValue)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.")
            .When(p => p.MinimumOrderValue.HasValue);
    }
}