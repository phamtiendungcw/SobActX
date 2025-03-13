using FluentResults;

using MediatR;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.DeleteStockMovement;

public abstract record DeleteStockMovementCommand(Guid Id) : IRequest<Result>;