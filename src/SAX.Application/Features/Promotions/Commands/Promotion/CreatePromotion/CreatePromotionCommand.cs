using FluentResults;

using MediatR;

using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.Commands.Promotion.CreatePromotion;

public record CreatePromotionCommand : IRequest<Result<Guid>>
{
    public CreatePromotionDto? CreatePromotionDto { get; set; }
}