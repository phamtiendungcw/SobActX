using FluentResults;

using MediatR;

using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;

public record CreateProductInventoryCommand : IRequest<Result<Guid>>
{
    public CreateProductDto? CreateProductDto { get; set; }
}