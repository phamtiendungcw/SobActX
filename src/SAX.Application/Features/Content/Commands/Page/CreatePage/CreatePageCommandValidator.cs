using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Page.CreatePage;

public sealed class CreatePageCommandValidator : AbstractValidator<CreatePageCommand>
{
    public CreatePageCommandValidator()
    {
        RuleFor(x => x.CreatePageDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreatePageDtoValidator());
    }
}