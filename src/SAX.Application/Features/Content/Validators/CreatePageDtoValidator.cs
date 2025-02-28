using FluentValidation;

using SAX.Application.Features.Content.DTOs.Page;

namespace SAX.Application.Features.Content.Validators;

public class CreatePageDtoValidator : AbstractValidator<CreatePageDto>
{
    public CreatePageDtoValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(200).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.Slug)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .MaximumLength(200).WithMessage("{PropertyName} không được vượt quá {MaxLength} ký tự.");

        RuleFor(p => p.ContentBody)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");

        RuleFor(p => p.PublishDate)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} phải là ngày trong quá khứ hoặc hiện tại.");

        RuleFor(p => p.AuthorId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.");
    }
}