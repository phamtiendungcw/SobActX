using FluentValidation;

using SAX.Application.Features.Products.DTOs;

namespace SAX.Application.Features.Products.Validators;

public sealed class ProductAttributeDtoValidator : AbstractValidator<ProductAttributeDto>
{
    public ProductAttributeDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.AttributeName)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}