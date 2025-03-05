using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Validators;

public class CreateCampaignDtoValidator : AbstractValidator<CreateCampaignDto>
{
    public CreateCampaignDtoValidator()
    {
        RuleFor(p => p.CampaignName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.EndDate)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");

        RuleFor(p => p.TargetAudience)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        RuleFor(p => p.Budget)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");
    }
}