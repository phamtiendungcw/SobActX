﻿using FluentValidation;

using SAX.Application.Features.Products.DTOs.ProductReview;

namespace SAX.Application.Features.Products.Validators;

public sealed class UpdateProductReviewDtoValidator : AbstractValidator<UpdateProductReviewDto>
{
    public UpdateProductReviewDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.CustomerId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.Rating)
            .InclusiveBetween(1, 5).WithMessage("{PropertyName} phải từ 1 đến 5.");
        RuleFor(p => p.Comment)
            .MaximumLength(1000).WithMessage("{PropertyName} không được vượt quá 1000 ký tự.");
    }
}