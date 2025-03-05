using FluentResults;

using MediatR;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.DeleteStockMovement;

public record DeleteStockMovementCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}