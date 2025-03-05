using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateEmailTemplateDtoValidator : AbstractValidator<UpdateEmailTemplateDto>
{
    public UpdateEmailTemplateDtoValidator()
    {
        RuleFor(p => p.EmailTemplateId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.TemplateName)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.TemplateName));

        RuleFor(p => p.Subject)
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
            .When(p => !string.IsNullOrEmpty(p.Subject));

        RuleFor(p => p.Body)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(p => !string.IsNullOrEmpty(p.Body)); // Body có thể null khi update
    }
}