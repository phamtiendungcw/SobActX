using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Validators;

public class UpdateSegmentDtoValidator : AbstractValidator<UpdateSegmentDto>
{
    public UpdateSegmentDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.SegmentName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}