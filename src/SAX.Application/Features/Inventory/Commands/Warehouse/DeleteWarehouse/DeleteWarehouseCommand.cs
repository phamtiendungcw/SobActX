using FluentResults;

using MediatR;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.DeleteWarehouse;

public abstract record DeleteWarehouseCommand(Guid Id) : IRequest<Result>;