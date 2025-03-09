using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.Campaign.CreateCampaign;

public class CreateCampaignCommandValidator : AbstractValidator<CreateCampaignCommand>
{
    public CreateCampaignCommandValidator()
    {
        RuleFor(x => x.CreateCampaignDto).NotNull().WithMessage("CreateCampaignDto is required.");
        RuleFor(x => x.CreateCampaignDto!).SetValidator(new CreateCampaignDtoValidator());
    }
}