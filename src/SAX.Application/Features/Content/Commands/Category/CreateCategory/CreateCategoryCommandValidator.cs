using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Category.CreateCategory;

public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.CreateCategoryDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateCategoryDtoValidator());
    }
}