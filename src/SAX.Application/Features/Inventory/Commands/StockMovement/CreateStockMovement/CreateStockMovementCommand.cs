using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.StockMovement;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.CreateStockMovement;

public record CreateStockMovementCommand : IRequest<Result<Guid>>
{
    public StockMovementDto? StockMovementDto { get; set; }
}