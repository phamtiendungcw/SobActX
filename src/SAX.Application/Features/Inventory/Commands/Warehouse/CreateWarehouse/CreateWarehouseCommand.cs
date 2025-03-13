using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.Warehouse;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.CreateWarehouse;

public abstract record CreateWarehouseCommand(CreateWarehouseDto CreateWarehouseDto) : IRequest<Result<Guid>>;