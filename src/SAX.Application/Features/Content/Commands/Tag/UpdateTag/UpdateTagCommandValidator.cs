using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Tag.UpdateTag;

public sealed class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
{
    public UpdateTagCommandValidator()
    {
        RuleFor(x => x.UpdateTagDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateTagDtoValidator());
    }
}