using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Validators;

public class CreateEmailTemplateDtoValidator : AbstractValidator<CreateEmailTemplateDto>
{
    public CreateEmailTemplateDtoValidator()
    {
        RuleFor(p => p.TemplateName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.Subject)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p => p.Body)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}