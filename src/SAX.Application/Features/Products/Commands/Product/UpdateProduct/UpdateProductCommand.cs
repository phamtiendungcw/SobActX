using FluentResults;

using MediatR;

using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Products.Commands.Product.UpdateProduct;

public record UpdateProductCommand : IRequest<Result>
{
    public UpdateProductDto? UpdateProductDto { get; set; }
}