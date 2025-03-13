using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Category.UpdateCategory;

public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.UpdateCategoryDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateCategoryDtoValidator());
    }
}