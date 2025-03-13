using FluentResults;

using MediatR;

using SAX.Application.Features.Promotions.DTOs.Promotion;

namespace SAX.Application.Features.Promotions.Commands.Promotion.CreatePromotion;

public abstract record CreatePromotionCommand(CreatePromotionDto CreatePromotionDto) : IRequest<Result<Guid>>;