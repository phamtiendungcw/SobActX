using FluentResults;

using MediatR;

using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;

public record CreateProductInventoryCommand : IRequest<Result<Guid>>
{
    public CreateProductInventoryDto? CreateProductInventoryDto { get; set; }
}