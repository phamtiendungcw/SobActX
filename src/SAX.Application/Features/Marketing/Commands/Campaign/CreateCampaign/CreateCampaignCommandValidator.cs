using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.Campaign.CreateCampaign;

public sealed class CreateCampaignCommandValidator : AbstractValidator<CreateCampaignCommand>
{
    public CreateCampaignCommandValidator()
    {
        RuleFor(x => x.CreateCampaignDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateCampaignDtoValidator());
    }
}