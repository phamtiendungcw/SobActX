using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.Campaign.UpdateCampaign;

public class UpdateCampaignCommandValidator : AbstractValidator<UpdateCampaignCommand>
{
    public UpdateCampaignCommandValidator()
    {
        RuleFor(x => x.UpdateCampaignDto).NotNull().WithMessage("UpdateCampaignDto is required.");
        RuleFor(x => x.UpdateCampaignDto!).SetValidator(new UpdateCampaignDtoValidator());
    }
}