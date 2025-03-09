using FluentValidation;

using SAX.Application.Features.Marketing.Validators;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.CreateEmailTemplate;

public class CreateEmailTemplateCommandValidator : AbstractValidator<CreateEmailTemplateCommand>
{
    public CreateEmailTemplateCommandValidator()
    {
        RuleFor(x => x.CreateEmailTemplateDto).NotNull().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.CreateEmailTemplateDto!).SetValidator(new CreateEmailTemplateDtoValidator());
    }
}