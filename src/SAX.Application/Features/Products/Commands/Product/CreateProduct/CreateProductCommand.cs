using FluentResults;

using MediatR;

using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Products.Commands.Product.CreateProduct;

public record CreateProductCommand : IRequest<Result<Guid>>
{
    public CreateProductDto? CreateProductDto { get; set; }
}