using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.UpdateEmailTemplate;

public class UpdateEmailTemplateCommandValidator : AbstractValidator<UpdateEmailTemplateCommand>
{
    public UpdateEmailTemplateCommandValidator()
    {
        RuleFor(x => x.UpdateEmailTemplateDto).NotNull().WithMessage("UpdateEmailTemplateDto is required.");
        RuleFor(x => x.UpdateEmailTemplateDto!).SetValidator(new UpdateEmailTemplateDtoValidator());
    }
}