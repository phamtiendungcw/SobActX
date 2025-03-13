using FluentResults;

using MediatR;

using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Products.Commands.Product.CreateProduct;

public abstract record CreateProductCommand(CreateProductDto CreateProductDto) : IRequest<Result<Guid>>;