using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.UpdateEmailCampaign;

public class UpdateEmailCampaignCommandValidator : AbstractValidator<UpdateEmailCampaignCommand>
{
    public UpdateEmailCampaignCommandValidator()
    {
        RuleFor(x => x.UpdateEmailCampaignDto).NotNull().WithMessage("UpdateEmailCampaignDto is required.");
        RuleFor(x => x.UpdateEmailCampaignDto!).SetValidator(new UpdateEmailCampaignDtoValidator());
    }
}