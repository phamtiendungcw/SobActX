using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateSegmentDtoValidator : AbstractValidator<UpdateSegmentDto>
{
    public UpdateSegmentDtoValidator()
    {
        RuleFor(p => p.SegmentId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.SegmentName)
            .MaximumLength(100).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.SegmentName));

        RuleFor(p => p.Criteria)
            .MaximumLength(1000).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.Criteria));
    }
}