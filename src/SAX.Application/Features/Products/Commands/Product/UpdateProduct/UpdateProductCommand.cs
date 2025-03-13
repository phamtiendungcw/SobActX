using FluentResults;

using MediatR;

using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Products.Commands.Product.UpdateProduct;

public abstract record UpdateProductCommand(UpdateProductDto UpdateProductDto) : IRequest<Result>;