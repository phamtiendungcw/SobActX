﻿using FluentValidation;

using SAX.Application.Features.Content.DTOs.Page;

namespace SAX.Application.Features.Content.Validators;

public sealed class CreatePageDtoValidator : AbstractValidator<CreatePageDto>
{
    public CreatePageDtoValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.Slug)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
        RuleFor(p => p.ContentSummary)
            .MaximumLength(500).WithMessage("{PropertyName} không được vượt quá 500 ký tự.");
        RuleFor(p => p.AuthorId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.PublishedAt)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .When(x => x.PublishedAt.HasValue);
    }
}