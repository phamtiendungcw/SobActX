using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateEmailTemplateDtoValidator : AbstractValidator<UpdateEmailTemplateDto>
{
    public UpdateEmailTemplateDtoValidator()
    {
        RuleFor(p => p.EmailTemplateId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.TemplateName)
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.TemplateName));

        RuleFor(p => p.Subject)
            .MaximumLength(200).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.Subject));

        RuleFor(p => p.Body)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => !string.IsNullOrEmpty(p.Body)); // Body có thể null khi update
    }
}