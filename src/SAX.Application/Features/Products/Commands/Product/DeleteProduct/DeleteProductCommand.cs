using FluentResults;

using MediatR;

namespace SAX.Application.Features.Products.Commands.Product.DeleteProduct;

public record DeleteProductCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}