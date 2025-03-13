using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Validators;

public sealed class CampaignDtoValidator : AbstractValidator<CampaignDto>
{
    public CampaignDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.CampaignName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.TargetAudience)
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}