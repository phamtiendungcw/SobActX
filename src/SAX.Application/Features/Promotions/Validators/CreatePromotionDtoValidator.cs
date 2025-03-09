using FluentValidation;

using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.Validators;

public class CreatePromotionDtoValidator : AbstractValidator<CreatePromotionDto>
{
    public CreatePromotionDtoValidator()
    {
        RuleFor(p => p.PromotionName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.Description)
            .MaximumLength(1000).WithMessage("{PropertyName} không được vượt quá 1000 ký tự.");
        RuleFor(p => p.PromotionType)
            .IsInEnum().WithMessage("{PropertyName} phải là một giá trị hợp lệ."); // Sử dụng IsInEnum()
        RuleFor(p => p.DiscountValue)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .GreaterThan(0).WithMessage("{PropertyName} phải lớn hơn 0.");
        RuleFor(p => p.CouponCode)
            .MaximumLength(50).WithMessage("{PropertyName} không được vượt quá 50 ký tự.");
    }
}