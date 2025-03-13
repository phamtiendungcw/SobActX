using FluentValidation;

using SAX.Application.Features.Content.Validators;

namespace SAX.Application.Features.Content.Commands.Media.CreateMedia;

public sealed class CreateMediaCommandValidator : AbstractValidator<CreateMediaCommand>
{
    public CreateMediaCommandValidator()
    {
        RuleFor(x => x.CreateMediaDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateMediaDtoValidator());
    }
}