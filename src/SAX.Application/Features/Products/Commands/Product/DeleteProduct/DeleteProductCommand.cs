using FluentResults;

using MediatR;

namespace SAX.Application.Features.Products.Commands.Product.DeleteProduct;

public abstract record DeleteProductCommand(Guid Id) : IRequest<Result>;