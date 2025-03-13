using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Media.UpdateMedia;

public sealed class UpdateMediaCommandValidator : AbstractValidator<UpdateMediaCommand>
{
    public UpdateMediaCommandValidator()
    {
        RuleFor(x => x.UpdateMediaDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateMediaDtoValidator());
    }
}