using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Page.UpdatePage;

public sealed class UpdatePageCommandValidator : AbstractValidator<UpdatePageCommand>
{
    public UpdatePageCommandValidator()
    {
        RuleFor(x => x.UpdatePageDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdatePageDtoValidator());
    }
}