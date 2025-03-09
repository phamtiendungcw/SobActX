using FluentResults;

using MediatR;

using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.Commands.Promotion.UpdatePromotion;

public record UpdatePromotionCommand : IRequest<Result>
{
    public UpdatePromotionDto? UpdatePromotionDto { get; set; }
}