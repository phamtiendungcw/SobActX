using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.Warehouse;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.UpdateWarehouse;

public record UpdateWarehouseCommand : IRequest<Result>
{
    public UpdateWarehouseDto? UpdateWarehouseDto { get; set; }
}