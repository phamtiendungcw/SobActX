using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.Warehouse;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.CreateWarehouse;

public record CreateWarehouseCommand : IRequest<Result<Guid>>
{
    public CreateWarehouseDto? CreateWarehouseDto { get; set; }
}