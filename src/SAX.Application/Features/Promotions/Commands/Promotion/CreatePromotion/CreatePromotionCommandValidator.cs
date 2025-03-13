using FluentValidation;

using SAX.Application.Features.Promotions.Validators;

namespace SAX.Application.Features.Promotions.Commands.Promotion.CreatePromotion;

public sealed class CreatePromotionCommandValidator : AbstractValidator<CreatePromotionCommand>
{
    public CreatePromotionCommandValidator()
    {
        RuleFor(p => p.CreatePromotionDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreatePromotionDtoValidator());
    }
}