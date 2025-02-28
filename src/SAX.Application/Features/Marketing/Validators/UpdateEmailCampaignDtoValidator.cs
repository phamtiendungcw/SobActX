using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateEmailCampaignDtoValidator : AbstractValidator<UpdateEmailCampaignDto>
{
    public UpdateEmailCampaignDtoValidator()
    {
        RuleFor(p => p.EmailCampaignId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.CampaignId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.CampaignId.HasValue);

        RuleFor(p => p.EmailTemplateId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.EmailTemplateId.HasValue);
    }
}