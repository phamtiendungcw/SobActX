using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Validators;

public class CreateCampaignDtoValidator : AbstractValidator<CreateCampaignDto>
{
    public CreateCampaignDtoValidator()
    {
        RuleFor(p => p.CampaignName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.StartDate)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .LessThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} phải nhỏ hơn hoặc bằng {ComparisonValue}.");

        RuleFor(p => p.EndDate)
            .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} phải lớn hơn hoặc bằng {ComparisonValue}.");

        RuleFor(p => p.TargetAudience)
            .MaximumLength(500).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Budget)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} phải lớn hơn hoặc bằng 0.");
    }
}