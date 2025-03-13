using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.StockMovement;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.CreateStockMovement;

public abstract record CreateStockMovementCommand(CreateStockMovementDto CreateStockMovementDto) : IRequest<Result<Guid>>;