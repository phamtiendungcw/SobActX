using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Validators;

public class CreateEmailTemplateDtoValidator : AbstractValidator<CreateEmailTemplateDto>
{
    public CreateEmailTemplateDtoValidator()
    {
        RuleFor(p => p.TemplateName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Subject)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(200).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Body)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");
    }
}