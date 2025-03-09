using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.CreateEmailCampaign;

public class CreateEmailCampaignCommandValidator : AbstractValidator<CreateEmailCampaignCommand>
{
    public CreateEmailCampaignCommandValidator()
    {
        RuleFor(x => x.CreateEmailCampaignDto).NotNull().WithMessage("CreateEmailCampaignDto is required.");
        RuleFor(x => x.CreateEmailCampaignDto!).SetValidator(new CreateEmailCampaignDtoValidator());
    }
}