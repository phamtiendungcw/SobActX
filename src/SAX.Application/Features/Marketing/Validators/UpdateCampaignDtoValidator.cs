using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateCampaignDtoValidator : AbstractValidator<UpdateCampaignDto>
{
    public UpdateCampaignDtoValidator()
    {
        RuleFor(p => p.CampaignId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.CampaignName)
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.CampaignName));

        RuleFor(p => p.StartDate)
            .LessThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} phải nhỏ hơn hoặc bằng {ComparisonValue}.")
            .When(p => p.StartDate.HasValue && p.EndDate.HasValue);

        RuleFor(p => p.EndDate)
            .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} phải lớn hơn hoặc bằng {ComparisonValue}.")
            .When(p => p.StartDate.HasValue && p.EndDate.HasValue);

        RuleFor(p => p.TargetAudience)
            .MaximumLength(500).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.TargetAudience));

        RuleFor(p => p.Budget)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.")
            .When(p => p.Budget.HasValue);
    }
}