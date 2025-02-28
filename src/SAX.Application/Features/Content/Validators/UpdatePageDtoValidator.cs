using FluentValidation;

using SAX.Application.Features.Content.DTOs.Page;

namespace SAX.Application.Features.Content.Validators;

public class UpdatePageDtoValidator : AbstractValidator<UpdatePageDto>
{
    public UpdatePageDtoValidator()
    {
        RuleFor(p => p.PageId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.Title)
            .MaximumLength(200).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.Title));

        RuleFor(p => p.Slug)
            .MaximumLength(200).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.")
            .When(p => !string.IsNullOrEmpty(p.Slug));

        RuleFor(p => p.PublishDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} phải là ngày trong quá khứ hoặc hiện tại.")
            .When(p => p.PublishDate.HasValue);

        RuleFor(p => p.AuthorId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .When(p => p.AuthorId.HasValue);
    }
}