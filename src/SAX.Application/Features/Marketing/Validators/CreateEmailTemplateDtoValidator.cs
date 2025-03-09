using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Validators;

public class CreateEmailTemplateDtoValidator : AbstractValidator<CreateEmailTemplateDto>
{
    public CreateEmailTemplateDtoValidator()
    {
        RuleFor(p => p.TemplateName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.Subject)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}