using FluentValidation;

using SAX.Application.Features.Products.Validators;

namespace SAX.Application.Features.Products.Commands.Product.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.UpdateProductDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateProductDtoValidator());
    }
}