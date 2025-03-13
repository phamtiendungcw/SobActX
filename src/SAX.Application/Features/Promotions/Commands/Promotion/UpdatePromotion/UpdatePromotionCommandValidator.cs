using FluentValidation;

using SAX.Application.Features.Promotions.Validators;

namespace SAX.Application.Features.Promotions.Commands.Promotion.UpdatePromotion;

public sealed class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
{
    public UpdatePromotionCommandValidator()
    {
        RuleFor(p => p.UpdatePromotionDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdatePromotionDtoValidator());
    }
}