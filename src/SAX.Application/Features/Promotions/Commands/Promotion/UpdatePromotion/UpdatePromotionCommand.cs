using FluentResults;

using MediatR;

using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.Commands.Promotion.UpdatePromotion;

public abstract record UpdatePromotionCommand(UpdatePromotionDto UpdatePromotionDto) : IRequest<Result>;