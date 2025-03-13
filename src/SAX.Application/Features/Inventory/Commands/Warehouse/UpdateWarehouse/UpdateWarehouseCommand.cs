using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.Warehouse;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.UpdateWarehouse;

public abstract record UpdateWarehouseCommand(UpdateWarehouseDto UpdateWarehouseDto) : IRequest<Result>;