using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.UpdateEmailCampaign;

public sealed class UpdateEmailCampaignCommandValidator : AbstractValidator<UpdateEmailCampaignCommand>
{
    public UpdateEmailCampaignCommandValidator()
    {
        RuleFor(x => x.UpdateEmailCampaignDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateEmailCampaignDtoValidator());
    }
}