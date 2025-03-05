using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.Validators;

public class CreatePromotionDtoValidator : AbstractValidator<CreatePromotionDto>
{
    public CreatePromotionDtoValidator()
    {
        RuleFor(p => p.PromotionName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.PromotionType)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.DiscountValue)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");

        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .LessThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}.");

        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");

        RuleFor(p => p.CouponCode)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

        RuleFor(p => p.MinimumOrderValue)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");
    }
}