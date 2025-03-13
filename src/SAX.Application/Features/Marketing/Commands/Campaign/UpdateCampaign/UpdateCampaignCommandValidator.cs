using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.Campaign.UpdateCampaign;

public sealed class UpdateCampaignCommandValidator : AbstractValidator<UpdateCampaignCommand>
{
    public UpdateCampaignCommandValidator()
    {
        RuleFor(x => x.UpdateCampaignDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateCampaignDtoValidator());
    }
}