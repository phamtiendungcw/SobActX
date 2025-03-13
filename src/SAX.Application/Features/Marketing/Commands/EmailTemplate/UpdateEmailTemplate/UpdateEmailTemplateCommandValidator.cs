using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.UpdateEmailTemplate;

public sealed class UpdateEmailTemplateCommandValidator : AbstractValidator<UpdateEmailTemplateCommand>
{
    public UpdateEmailTemplateCommandValidator()
    {
        RuleFor(x => x.UpdateEmailTemplateDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateEmailTemplateDtoValidator());
    }
}