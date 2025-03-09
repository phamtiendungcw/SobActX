using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Products.Commands.Product.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productToDelete = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
        if (productToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Products.Product), request.Id).Message);

        await _productRepository.DeleteAsync(productToDelete, cancellationToken);

        return Result.Ok();
    }
}