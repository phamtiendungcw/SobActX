using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Tag.CreateTag;

public sealed class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagCommandValidator()
    {
        RuleFor(x => x.CreateTagDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateTagDtoValidator());
    }
}