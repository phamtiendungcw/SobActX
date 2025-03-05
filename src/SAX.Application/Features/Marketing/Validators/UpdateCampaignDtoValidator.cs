using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateCampaignDtoValidator : AbstractValidator<UpdateCampaignDto>
{
    public UpdateCampaignDtoValidator()
    {
        RuleFor(p => p.CampaignId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.CampaignName)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.CampaignName));

        RuleFor(p => p.StartDate)
            .LessThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}.")
            .When(p => p.StartDate.HasValue && p.EndDate.HasValue); // Validate StartDate only when EndDate is provided

        RuleFor(p => p.EndDate)
            .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.")
            .When(p => p.StartDate.HasValue && p.EndDate.HasValue); // Validate EndDate only when StartDate is provided

        RuleFor(p => p.TargetAudience)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
            .When(p => !string.IsNullOrEmpty(p.TargetAudience));

        RuleFor(p => p.Budget)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.")
            .When(p => p.Budget.HasValue);
    }
}