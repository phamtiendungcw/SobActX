using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.CreateEmailCampaign;

public sealed class CreateEmailCampaignCommandValidator : AbstractValidator<CreateEmailCampaignCommand>
{
    public CreateEmailCampaignCommandValidator()
    {
        RuleFor(x => x.CreateEmailCampaignDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateEmailCampaignDtoValidator());
    }
}