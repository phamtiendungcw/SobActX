using FluentValidation;

using SAX.Application.Features.Products.DTOs;

namespace SAX.Application.Features.Products.Validators;

public class ProductAttributeValueDtoValidator : AbstractValidator<ProductAttributeValueDto>
{
    public ProductAttributeValueDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.ProductAttributeId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.Value)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.")
            .MaximumLength(255).WithMessage("{PropertyName} không được vượt quá 255 ký tự.");
    }
}