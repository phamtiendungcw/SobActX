using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateSegmentDtoValidator : AbstractValidator<UpdateSegmentDto>
{
    public UpdateSegmentDtoValidator()
    {
        RuleFor(p => p.SegmentId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.SegmentName)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.SegmentName));

        RuleFor(p => p.Criteria)
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.")
            .When(p => !string.IsNullOrEmpty(p.Criteria));
    }
}