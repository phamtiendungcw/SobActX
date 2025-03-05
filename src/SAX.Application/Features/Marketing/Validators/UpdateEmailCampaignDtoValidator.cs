using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateEmailCampaignDtoValidator : AbstractValidator<UpdateEmailCampaignDto>
{
    public UpdateEmailCampaignDtoValidator()
    {
        RuleFor(p => p.EmailCampaignId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.CampaignId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => p.CampaignId.HasValue);

        RuleFor(p => p.EmailTemplateId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => p.EmailTemplateId.HasValue);
    }
}