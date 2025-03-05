using FluentResults;

using MediatR;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.DeleteWarehouse;

public record DeleteWarehouseCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}