using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.Validators;

public class CreateEmailCampaignDtoValidator : AbstractValidator<CreateEmailCampaignDto>
{
    public CreateEmailCampaignDtoValidator()
    {
        RuleFor(p => p.CampaignId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.EmailTemplateId)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}