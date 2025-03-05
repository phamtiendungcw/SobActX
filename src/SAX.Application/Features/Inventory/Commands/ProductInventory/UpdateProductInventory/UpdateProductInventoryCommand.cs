using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.UpdateProductInventory;

public record UpdateProductInventoryCommand : IRequest<Result>
{
    public UpdateProductInventoryDto? UpdateProductInventoryDto { get; set; }
}